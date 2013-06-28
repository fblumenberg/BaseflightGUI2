Imports GMap.NET.WindowsForms
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers

Module modMap
    Public dtWayPoints As New DataTable
    Public editWPDr As DataRow
    Public isNewWayPoint As Boolean = False

    Public pointLng As Double = 0
    Public pointLat As Double = 0

    Dim wLogStream As IO.StreamWriter
    Dim wKMLLogStream As IO.StreamWriter
    Public bLogRunning As Boolean = False
    Public bKMLLogRunning As Boolean = False

    Public GPS_lat_old As Integer, GPS_lon_old As Integer
    Public GPSPresent As Boolean = True

    'Map Overlays
    Public overlayCopterPosition As GMapOverlay '????
    Public drawnpolygons As GMapOverlay
    Public routes As GMapOverlay
    ' static so can update from GPS
    Public markers As GMapOverlay
    Public polygons As GMapOverlay
    Public positions As GMapOverlay     'Show Quad poistion
    Public WProutes As GMapOverlay  '
    Public WayPoints As GMapOverlay     '

    Public mapProviders As GMapProvider()
    Public copterPos As New PointLatLng(47.402489, 19.071558)
    'Just the corrds of my flying place
    Public isMouseDown As Boolean = False
    Public isMouseDraging As Boolean = False

    Public bPosholdRecorded As Boolean = False
    Public bHomeRecorded As Boolean = False

    ' marker
    Public currentMarker As GMapMarker
    Public CurentRectMarker As GMapMarkerRect = Nothing
    Public CurentWayPoint As GMapMarkerWayPoint = Nothing
    Public center As GMapMarker = New GMapMarkerCross(New PointLatLng(0.0, 0.0))

    Public drawnpolygon As GMapPolygon
    Public polygon As GMapPolygon

    ' layers
    Public Grout As GMapRoute
    Public GWPRout As GMapRoute
    Public points As New List(Of PointLatLng)()

    Public copterPosMarker As GMapMarkerCross
    Public GPS_pos As PointLatLng
    Public [end] As PointLatLng
    Public start As PointLatLng

    Public Function getBmpHeading(ByVal Heading As Integer) As Bitmap
        ' Copy the output bitmap from the source image.
        Dim bm_in As New Bitmap(My.Resources.Rounded_Arrow_Up_Black_32_n_p)

        ' Make an array of points defining the
        ' image's corners.
        Dim wid As Single = bm_in.Width
        Dim hgt As Single = bm_in.Height
        Dim corners As Point() = { _
            New Point(0, 0), _
            New Point(wid, 0), _
            New Point(0, hgt), _
            New Point(wid, hgt)}

        ' Translate to center the bounding box at the origin.
        Dim cx As Single = wid / 2
        Dim cy As Single = hgt / 2
        Dim i As Long
        For i = 0 To 3
            corners(i).X -= cx
            corners(i).Y -= cy
        Next i

        ' Rotate.
        Dim theta As Single = (Single.Parse(Heading) * Math.PI / 180.0) * -1
        Dim sin_theta As Single = Math.Sin(theta)
        Dim cos_theta As Single = Math.Cos(theta)
        Dim X As Single
        Dim Y As Single
        For i = 0 To 3
            X = corners(i).X
            Y = corners(i).Y
            corners(i).X = X * cos_theta + Y * sin_theta
            corners(i).Y = -X * sin_theta + Y * cos_theta
        Next i

        ' Translate so X >= 0 and Y >=0 for all corners.
        Dim xmin As Single = corners(0).X
        Dim ymin As Single = corners(0).Y
        For i = 1 To 3
            If xmin > corners(i).X Then xmin = corners(i).X
            If ymin > corners(i).Y Then ymin = corners(i).Y
        Next i
        For i = 0 To 3
            corners(i).X -= xmin
            corners(i).Y -= ymin
        Next i

        ' Create an output Bitmap and Graphics object.
        Dim bm_out As New Bitmap(CInt(-2 * xmin), CInt(-2 * ymin))
        Dim gr_out As Graphics = Graphics.FromImage(bm_out)

        ' Drop the last corner lest we confuse DrawImage,
        ' which expects an array of three corners.
        ReDim Preserve corners(2)

        ' Draw the result onto the output Bitmap.
        gr_out.DrawImage(bm_in, corners)

        ' Display the result.
        Return bm_out
    End Function

    Public Sub askForMapData()
        MSPquery(MSP_STATUS)
        frmMain.lblV_cycletime.Text = [String].Format("{0:0000} µs", mw_gui.cycleTime)
        MSPquery(MSP_ATTITUDE)
        MSPquery(MSP_COMP_GPS)
        MSPquery(MSP_RAW_GPS)
        'Do some logging
        If bKMLLogRunning Then
            If GPS_lat_old <> mw_gui.GPS_latitude OrElse GPS_lon_old <> mw_gui.GPS_longitude Then
                wKMLLogStream.WriteLine("{0},{1},{2}", CDec(mw_gui.GPS_longitude) / 10000000, CDec(mw_gui.GPS_latitude) / 10000000, mw_gui.GPS_altitudeMSL)
                GPS_lat_old = mw_gui.GPS_latitude
                GPS_lon_old = mw_gui.GPS_longitude
            End If
            If Not bHomeRecorded AndAlso (mw_gui.GPS_home_lon <> 0) Then
                addKMLMarker("Home position", mw_gui.GPS_home_lon, mw_gui.GPS_home_lat, mw_gui.GPS_altitudeMSL)
                bHomeRecorded = True
            End If
            If Not bPosholdRecorded AndAlso (mw_gui.GPS_poshold_lon <> 0) Then
                addKMLMarker("PosHold", mw_gui.GPS_poshold_lon, mw_gui.GPS_poshold_lat, mw_gui.GPS_altitudeMSL)
                bPosholdRecorded = True
            End If
        End If
        If Convert.ToBoolean(mw_gui.GPS_update) = True Then
            frmMain.picMapGPSUpdate.Image = My.Resources.gps_led_green
        Else
            frmMain.picMapGPSUpdate.Image = My.Resources.gps_led_red
        End If
    End Sub

    Public Sub updateTPMap()
        Try
            Dim GPS_latitude As Double = mw_gui.GPS_latitude / 10000000
            Dim GPS_longitude As Double = mw_gui.GPS_longitude / 10000000
            If mw_gui.GPS_fix > 0 Then
                copterPos = New PointLatLng(GPS_latitude, GPS_longitude)
                frmMain.picGPS.Image = My.Resources.gps_green_x32
                If frmMain.chkSetToLiveData.Checked = True Then
                    frmMain.MainMap.Position = copterPos
                End If
            Else
                frmMain.picGPS.Image = My.Resources.gps_red_x32
            End If

            frmMain.lblV_GPS_lat.Text = [String].Format("{0:0.000000}", GPS_latitude)
            frmMain.lblV_GPS_lon.Text = [String].Format("{0:0.000000}", GPS_longitude)
            frmMain.lblV_GPS_numsat.Text = mw_gui.GPS_numSat & "/" & mw_gui.GPS_fix
            frmMain.lblV_GPS_alt.Text = mw_gui.GPS_altitudeMSL

            GPS_pos.Lat = GPS_latitude
            GPS_pos.Lng = GPS_longitude

            positions.Markers.Clear()

            If ((mw_gui.mode And (1 << 5)) > 0) AndAlso (mw_gui.GPS_home_lon <> 0) Then
                'ARMED
                Dim GPS_home As New PointLatLng(CDbl(mw_gui.GPS_home_lat) / 10000000, CDbl(mw_gui.GPS_home_lon) / 10000000)
                positions.Markers.Add(New GMapMarkerHome(GPS_home))
            End If

            If ((mw_gui.mode And (1 << 7)) > 0) AndAlso (mw_gui.GPS_poshold_lon <> 0) Then
                'poshold
                Dim GPS_poshold As New PointLatLng(CDbl(mw_gui.GPS_poshold_lat) / 10000000, CDbl(mw_gui.GPS_poshold_lon) / 10000000)
                positions.Markers.Add(New GMapMarkerGoogleRed(GPS_poshold))
            End If

            positions.Markers.Add(New GMapMarkerQuad(GPS_pos, mw_gui.heading, 0, 0))

            If frmMain.chkSetToLiveData.Checked = True Then
                If mw_gui.GPS_numSat > 3 Then
                    Grout.Points.Add(GPS_pos)
                    frmMain.MainMap.Position = GPS_pos
                End If
            End If
            frmMain.MainMap.Invalidate()

            If isNewWayPoint = True Then
                updateWayPointRoute()
                frmMain.Refresh()
                isNewWayPoint = False
            End If
        Catch ex As Exception
            frmError.lastCommand = "updateTPMap()"
            frmError.myEx = ex
            If frmError.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                System.Windows.Forms.Application.Exit()
            End If
        End Try
    End Sub

    Public Sub updateWayPointRoute()
        GWPRout.Points.Clear()
        For Each dr As DataRow In dtWayPoints.Rows
            GWPRout.Points.Add(New GMap.NET.PointLatLng(dr("Lat"), dr("Lon")))
        Next
        Dim pos As GMap.NET.PointLatLng = frmMain.MainMap.Position
        frmMain.MainMap.Position = New GMap.NET.PointLatLng(pos.Lat + 0.00000000001, pos.Lng)
        frmMain.MainMap.Position = pos
    End Sub

    Public Sub openKMLLog()
        Try
            If System.IO.Directory.Exists(sLogFolder) = False Then
                System.IO.Directory.CreateDirectory(sLogFolder)
            End If
            wKMLLogStream = New System.IO.StreamWriter(sLogFolder + "\BaseflightGPSTrack" + [String].Format("-{0:yymmdd-hhmm}.kml", DateTime.Now))
        Catch
            MessageBox.Show(frmMain, "Unable to open KMLlog file at " + sLogFolder & "\BasefligthGPSTrack" & [String].Format("-{0:yymmdd-hhmm}.kml", DateTime.Now), "Error opening KMLlog", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Try
            If wKMLLogStream IsNot Nothing Then
                wKMLLogStream.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
                wKMLLogStream.WriteLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"">")
                wKMLLogStream.WriteLine("<Document>")
                wKMLLogStream.WriteLine("<Placemark>")
                wKMLLogStream.WriteLine("<Style><LineStyle><color>#ef00ffff</color><width>5</width></LineStyle></Style>")
                wKMLLogStream.WriteLine("<name>MultiWii flight log</name>")
                wKMLLogStream.WriteLine("<LineString>")
                wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>")
                wKMLLogStream.WriteLine("<tessellate>1</tessellate>")
                wKMLLogStream.WriteLine("<coordinates>")
                bKMLLogRunning = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub closeKMLLog()
        Try
            wKMLLogStream.WriteLine("</coordinates>")
            wKMLLogStream.WriteLine("</LineString>")
            wKMLLogStream.WriteLine("</Placemark>")
            wKMLLogStream.WriteLine("</Document>")
            wKMLLogStream.WriteLine("</kml>")
            wKMLLogStream.Flush()
            wKMLLogStream.Close()
            wKMLLogStream.Dispose()
            bKMLLogRunning = False
        Catch ex As Exception

        End Try
    End Sub

    Public Sub addKMLMarker(description As String, lon As Double, lat As Double, alt As Double)
        Try
            'Close open LineStringPlacemark
            wKMLLogStream.WriteLine("</coordinates>")
            wKMLLogStream.WriteLine("</LineString>")
            wKMLLogStream.WriteLine("</Placemark>")

            wKMLLogStream.WriteLine("<Placemark>")
            wKMLLogStream.WriteLine("<name>" & description & "</name>")
            wKMLLogStream.WriteLine("<Point>")
            wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>")
            wKMLLogStream.WriteLine("<coordinates>")
            wKMLLogStream.WriteLine("{0},{1},{2}", CDec(lon) / 10000000, CDec(lat) / 10000000, alt)
            wKMLLogStream.WriteLine("</coordinates>")
            wKMLLogStream.WriteLine("</Point>")
            wKMLLogStream.WriteLine("</Placemark>")

            'open another LineString
            wKMLLogStream.WriteLine("<Placemark>")
            wKMLLogStream.WriteLine("<Style><LineStyle><color>#ef00ffff</color><width>5</width></LineStyle></Style>")
            wKMLLogStream.WriteLine("<name>MultiWii flight log</name>")
            wKMLLogStream.WriteLine("<LineString>")
            wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>")
            wKMLLogStream.WriteLine("<tessellate>1</tessellate>")
            wKMLLogStream.WriteLine("<coordinates>")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub addpolygonmarker(tag As String, lng As Double, lat As Double, alt As Integer, color As System.Nullable(Of Color))
        Try
            Dim point As New PointLatLng(lat, lng)
            Dim m As New GMapMarkerGoogleGreen(point)
            m.ToolTipMode = MarkerTooltipMode.Always
            m.ToolTipText = tag
            m.Tag = tag

            'ArdupilotMega.GMapMarkerRectWPRad mBorders = new ArdupilotMega.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), frmmain.MainMap);
            Dim mBorders As New GMapMarkerRect(point)
            If True Then
                mBorders.InnerMarker = m
                mBorders.wprad = CInt(Math.Truncate(Single.Parse("5")))
                frmMain.MainMap = frmMain.MainMap
                If color.HasValue Then
                    mBorders.Color = color.Value
                End If
            End If

            markers.Markers.Add(m)
            markers.Markers.Add(mBorders)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RegeneratePolygon()
        Try
            Dim polygonPoints As New List(Of PointLatLng)()

            If markers Is Nothing Then
                Return
            End If

            For Each m As GMapMarker In markers.Markers
                If TypeOf m Is GMapMarkerRect Then
                    m.Tag = polygonPoints.Count
                    polygonPoints.Add(m.Position)
                End If
            Next

            If polygon Is Nothing Then
                polygon = New GMapPolygon(polygonPoints, "polygon test")
                polygons.Polygons.Add(polygon)
            Else
                polygon.Points.Clear()
                polygon.Points.AddRange(polygonPoints)

                polygon.Stroke = New Pen(Color.Yellow, 4)
                polygon.Fill = Brushes.Transparent

                If polygons.Polygons.Count = 0 Then
                    polygons.Polygons.Add(polygon)
                Else
                    frmMain.MainMap.UpdatePolygonLocalPosition(polygon)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub b_start_KML_log_Click(sender As Object, e As EventArgs)
        Try
            If bKMLLogRunning Then
                frmMain.cmdStart_KML_log.Text = "Start GPS Log"
                frmMain.cmdStart_KML_log.BackColor = Color.Gray
                frmMain.Refresh()
                closeKMLLog()
            Else
                openKMLLog()
                If bKMLLogRunning Then
                    frmMain.cmdStart_KML_log.Text = "Stop STOP Log"
                    frmMain.cmdStart_KML_log.BackColor = Color.IndianRed
                    frmMain.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub b_Clear_Route_Click(sender As Object, e As EventArgs)
        Try
            Grout.Points.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub saveWayPointToDisc()
        Dim sfdSaveWayPoints As New SaveFileDialog()
        sfdSaveWayPoints.Filter = "Baseflight WayPoint File|*.wpf"
        sfdSaveWayPoints.Title = "Save WayPoints to file"
        sfdSaveWayPoints.InitialDirectory = sWayPointFolder
        Dim invalidChars As String = System.Text.RegularExpressions.Regex.Escape(New String(IO.Path.GetInvalidFileNameChars()))
        Dim invalidReStr As String = String.Format("[{0} ]+", invalidChars)
        Dim fn As String = System.Text.RegularExpressions.Regex.Replace(frmMain.txtWPComment.Text, invalidReStr, "_")
        fn = fn & [String].Format("{0:yymmdd-hhmm}", DateTime.Now)
        sfdSaveWayPoints.FileName = fn
        sfdSaveWayPoints.ShowDialog()
        If sfdSaveWayPoints.FileName <> "" Then
            dtWayPoints.WriteXml(sfdSaveWayPoints.FileName, System.Data.XmlWriteMode.WriteSchema)
            sWayPointFolder = System.IO.Path.GetDirectoryName(sfdSaveWayPoints.FileName)
            ini.Write("GUI", "WayPointFolder", sWayPointFolder)
        End If
    End Sub

    Public Sub loadWayPointFromDisc()
        Dim ofdLoadWayPoints As New OpenFileDialog()
        ofdLoadWayPoints.Filter = "Baseflight WayPoint File|*.wpf"
        ofdLoadWayPoints.Title = "Load WayPoints from file"
        ofdLoadWayPoints.InitialDirectory = sWayPointFolder
        If ofdLoadWayPoints.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'we have file to open
            dtWayPoints.ReadXml(ofdLoadWayPoints.FileName)
            sWayPointFolder = System.IO.Path.GetDirectoryName(ofdLoadWayPoints.FileName)
            ini.Write("GUI", "WayPointFolder", sWayPointFolder)
        End If
    End Sub

    Public Sub GoToHomePosition()
        pointLng = ini.ReadDouble("GPS", "Longtitude", 7.230758)
        pointLat = ini.ReadDouble("GPS", "Latitude", 51.462447)
        copterPos = New GMap.NET.PointLatLng(pointLat, pointLng)
        frmMain.MainMap.Position = copterPos
    End Sub

    Public Sub createDTWayPoints()
        Try
            If dtWayPoints.Columns.Count = 0 Then
                Dim col As DataColumn
                col = New DataColumn("WPNo", GetType(System.Byte))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("Lat", GetType(System.Double))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("Lon", GetType(System.Double))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("Alt", GetType(System.Byte))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("Heading", GetType(System.Int16))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("TimeToStay", GetType(System.Int16))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("Action", GetType(System.Byte))
                dtWayPoints.Columns.Add(col)
                col = New DataColumn("ActionParameter", GetType(System.UInt16))
                dtWayPoints.Columns.Add(col)
                dtWayPoints.TableName = "WayPoints"
            End If
            frmMain.dgWayPoints.AutoGenerateColumns = False
            frmMain.dgWayPoints.DataSource = dtWayPoints
            frmMain.colWPNumber.DataPropertyName = "WPNo"
            frmMain.colWPLat.DataPropertyName = "Lat"
            frmMain.colWPLng.DataPropertyName = "Lon"
            frmMain.colWPAlt.DataPropertyName = "Alt"
            frmMain.colWPHeading.DataPropertyName = "Heading"
            frmMain.colWPTimeToStay.DataPropertyName = "TimeToStay"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub renumberWPNO()
        If dtWayPoints.Rows.Count > 0 Then
            Dim no As Int16 = 1
            For Each dr As DataRow In dtWayPoints.Rows
                dr("WPNo") = no
                no += 1
            Next
            dtWayPoints.Select("WPNo = " & no - 1)(0)("WPNo") = 16
        End If
    End Sub

    Public Sub writeWayPointSettings()
        renumberWPNO()
        If dtWayPoints.Rows.Count > 0 Then
            Dim no As Int16 = 1
            For Each dr As DataRow In dtWayPoints.Rows
                setWayPoint(dr)
                no += 1
            Next
        End If
    End Sub

    Public Sub readWayPointSettings()
        If comError = True Then Exit Sub
        dtWayPoints.Clear()
        For i As Int16 = 1 To 16
            readWayPoint(i)
            sleep(100)
        Next
        updateWayPointRoute()
    End Sub

    Public Sub readWayPoint(ByVal wp_no As Integer)
        Dim c As Byte = 0
        Dim o As Byte()
        o = New Byte(9) {}
        ' with checksum 
        o(0) = Convert.ToByte(Asc("$"c))
        o(1) = Convert.ToByte(Asc("M"c))
        o(2) = Convert.ToByte(Asc("<"c))
        o(3) = Convert.ToByte(1)
        c = c Xor o(3)
        'no payload 
        o(4) = Convert.ToByte(MSP_WP)
        c = c Xor o(4)
        o(5) = Convert.ToByte(wp_no)
        c = c Xor o(5)
        o(6) = Convert.ToByte(c)
        Try
            If isConnected = True Then
                serialPort.Write(o, 0, 7)
            End If
        Catch ex As Exception
            comError = True
            lostConnection()
        End Try
    End Sub

    Public Sub setWayPoint(ByVal dr As DataRow)
        Dim wp_no As Byte = CByte(dr("WPNo")) 'wp_no = read8();    //get the wp number
        Dim lat As Int32 = Convert.ToInt32(dr("Lat") * 10000000)             'lat = read32();
        Dim lon As Int32 = Convert.ToInt32(dr("Lon") * 10000000)             'lon = read32();
        Dim alt As Int32 = Convert.ToInt32(dr("Alt") * 10000000)             'alt = read32();     // to set altitude (cm)
        Dim heading As Int16 = Convert.ToInt16(dr("Heading"))     'read16();           // future: to set heading (deg)
        Dim time As Int16 = Convert.ToInt16(dr("TimeToStay"))     'read16();           // future: to set time to stay (ms)
        Dim action As Byte = CByte(dr("Action"))            'read8();            // future: to set nav flag
        Dim actionparameter As Int16 = Convert.ToInt16(dr("ActionParameter"))       'read16();           // future: to set action flag

        Dim size As Integer = 20
        Dim checksum As Byte = 0
        Dim Buffer As Byte()
        Dim bptr As Integer = 0
        Buffer = New Byte(150) {}
        ' with checksum 
        Buffer(0) = Convert.ToByte(Asc("$"c))
        bptr += 1
        Buffer(1) = Convert.ToByte(Asc("M"c))
        bptr += 1
        Buffer(2) = Convert.ToByte(Asc("<"c))
        bptr += 1
        Buffer(3) = Convert.ToByte(size)
        bptr += 1
        Buffer(4) = Convert.ToByte(MSP_SET_WP)
        'wp_no
        Buffer(5) = Convert.ToByte(wp_no)
        'lat
        bptr = 6
        Buffer(bptr) = Convert.ToByte(lat And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((lat >> 8) And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((lat >> 16) And &HFF)
        bptr += 1
        Buffer(bptr) = CByte((lat >> 24) And &HFF)
        bptr += 1
        'lon
        Buffer(bptr) = Convert.ToByte(lon And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((lon >> 8) And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((lon >> 16) And &HFF)
        bptr += 1
        Buffer(bptr) = CByte((lon >> 24) And &HFF)
        bptr += 1
        'alt
        Buffer(bptr) = Convert.ToByte(alt And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((alt >> 8) And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((alt >> 16) And &HFF)
        bptr += 1
        Buffer(bptr) = CByte((alt >> 24) And &HFF)
        bptr += 1
        'heading
        Buffer(bptr) = Convert.ToByte(heading And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((heading >> 8) And &HFF)
        bptr += 1
        'time
        Buffer(bptr) = Convert.ToByte(time And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((time >> 8) And &HFF)
        bptr += 1
        'flag
        Buffer(bptr) = Convert.ToByte(action)
        bptr += 1
        'Action
        Buffer(bptr) = Convert.ToByte(actionparameter And &HFF)
        bptr += 1
        Buffer(bptr) = Convert.ToByte((actionparameter >> 8) And &HFF)
        bptr += 1

        For i As Integer = 3 To bptr - 1
            checksum = checksum Xor Buffer(i)
        Next
        Buffer(bptr) = checksum
        bptr += 1
        Try
            If isConnected = True Then
                serialPort.Write(Buffer, 0, bptr)
            End If
        Catch ex As Exception
            comError = True
            lostConnection()
        End Try
    End Sub

#Region "Distance Helpers"
    Public Function distance(ByVal oldPos As GMap.NET.PointLatLng, ByVal newPos As GMap.NET.PointLatLng, Optional ByVal unit As String = "K") As Double
        Dim result As Double = 0
        If oldPos.Lat <> 0 Or oldPos.Lng <> 0 Then
            Dim theta As Double = 0
            Dim dist As Double = 0
            theta = oldPos.Lng - newPos.Lng
            dist = Math.Sin(deg2rad(oldPos.Lat)) * Math.Sin(deg2rad(newPos.Lat)) + Math.Cos(deg2rad(oldPos.Lat)) * Math.Cos(deg2rad(newPos.Lat)) * Math.Cos(deg2rad(theta))
            dist = acos(dist)
            dist = rad2deg(dist)
            result = dist * 60 * 1.1515
            Select Case UCase(unit)
                Case "K"
                    result = result * 1.609344 * 1000
                Case "M"
                    result = result * 0.8684 * 1000
            End Select
        End If
        Return result
    End Function

    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    ':::  This function get the arccos function using arctan function   :::
    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    Function acos(rad) As Double
        Dim result As Double
        If Math.Abs(rad) <> 1 Then
            result = Math.PI / 2 - Math.Atan(rad / Math.Sqrt(1 - rad * rad))
        ElseIf rad = -1 Then
            result = Math.PI
        End If
        Return result
    End Function


    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    ':::  This function converts decimal degrees to radians             :::
    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    Function deg2rad(Deg)
        deg2rad = CDbl(Deg * Math.PI / 180)
    End Function

    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    ':::  This function converts radians to decimal degrees             :::
    '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    Function rad2deg(Rad)
        rad2deg = CDbl(Rad * 180 / Math.PI)
    End Function
#End Region

End Module
