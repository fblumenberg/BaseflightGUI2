Public Class baseflight_data_gui

    Public ax As Integer
    'AccSmooth
    Public ay As Integer
    'AccSmooth
    Public az As Integer
    'AccSmooth
    Public gx As Integer
    'Gyro Smooth
    Public gy As Integer
    'Gyro Smooth
    Public gz As Integer
    'Gyro Smooth
    Public magx As Integer
    'Magnetometer 
    Public magy As Integer
    'Magnetometer 
    Public magz As Integer
    'Magnetometer 
    Public baro As Integer
    Public heading As Integer
    Public servos As Integer()
    Public motors As Integer()
    Public rcRoll As Integer, rcPitch As Integer, rcYaw As Integer, rcThrottle As Integer
    Public rcAUX As Integer()
    'public int rcAux1, rcAux2, rcAux3, rcAux4, rcAux5, rcAux6, rcAux7, rcAux8;
    Public present As Integer
    'What sensors are present?
    Public mode As UInt32
    'What mode are we in ?
    Public i2cErrors As Integer
    Public cycleTime As Integer
    Public angx As Integer
    'Must be /10
    Public angy As Integer
    'Must be /10
    Public multiType As Byte
    Public version As Byte
    Public protocol_version As Byte
    Public capability As UInt32
    'Public pidP As Byte()
    'Public pidI As Byte()
    'Public pidD As Byte()
    'Public rcRate As Byte
    'Public rcExpo As Byte
    'Public RollPitchRate As Byte
    'Public YawRate As Byte
    'Public DynThrPID As Byte
    'Public ThrottleMID As Byte
    'Public ThrottleEXPO As Byte
    'Public activation As Int32()
    Public bUpdateBoxNames As Boolean
    Public GPS_distanceToHome As Integer
    Public GPS_directionToHome As Integer
    Public GPS_update As Byte
    Public GPS_latitude As Integer
    Public GPS_longitude As Integer
    Public GPS_altitude As Int32
    Public GPS_altitudeMSL As Int32
    Public GPS_hAcc As UInt32
    Public GPS_vAcc As UInt32
    Public GPS_speed As Integer
    Public GPS_home_pos As Boolean
    Public GPS_home_lat As Int32
    Public GPS_home_lon As Int32
    Public GPS_home_alt As Int32
    Public GPS_poshold_lat As Int32
    Public GPS_poshold_lon As Int32
    Public GPS_poshold_alt As Int32
    Public GPS_numCH As Integer
    Public GPS_chn(16) As Integer
    Public GPS_svid(16) As Integer
    Public GPS_quality(16) As Integer
    Public GPS_cno(16) As Integer


    Public GPS_Count As Integer
    Public GPS_Error As Integer
    Public GPS_Hz As Integer
    Public GPS_ms_SVINFO As Integer
    Public GPS_ms_POSLLH As Integer
    Public GPS_ms_SOL As Integer
    Public GPS_ms_VELNED As Integer
    'NAV_SOL
    Public GPS_fix As Byte
    Public GPS_fix_status As Byte
    Public GPS_ecef_x As Int32
    Public GPS_ecef_y As Int32
    Public GPS_ecef_z As Int32
    Public GPS_position_accuracy_3d As UInt32
    Public GPS_ecef_x_velocity As Int32
    Public GPS_ecef_y_velocity As Int32
    Public GPS_ecef_z_velocity As Int32
    Public GPS_speed_accuracy As UInt32
    Public GPS_position_DOP As UInt16
    Public GPS_numSat As Byte

    'NAV_VELNED
    Public GPS_ned_north As Int32
    Public GPS_ned_east As Int32
    Public GPS_ned_down As Int32
    Public GPS_speed_3d As UInt32
    Public GPS_speed_2d As UInt32
    Public GPS_heading_2d As Int32
    Public GPS_speed_accuracy1 As Int32
    Public GPS_heading_accuracy As UInt32

    Public pMeterSum As Integer
    'Public powerTrigger As Integer
    Public vBat As Byte
    Public Temp As Integer
    Public Sonar As Integer
    Public debug1 As Integer, debug2 As Integer, debug3 As Integer, debug4 As Integer
    Public debugstr As String
    Public comment As String
    Public firmware As String

    Private iPIDItems As Integer, iCheckBoxItems As Integer
    Private iSwVer As Integer
    Private bCompatibilityMode As Boolean

    'Constructor
    Public Sub New(pidItems As Integer, checkboxItems As Integer, iSoftwareVersion As Integer)
        motors = New Integer(7) {}
        servos = New Integer(7) {}
        rcAUX = New Integer(12) {}

        'pidP = New Byte(pidItems - 1) {}
        'pidI = New Byte(pidItems - 1) {}
        'pidD = New Byte(pidItems - 1) {}

        'activation = New Int32(checkboxItems - 1) {}

        iPIDItems = pidItems
        iCheckBoxItems = checkboxItems
        iSwVer = iSoftwareVersion

        bUpdateBoxNames = False
    End Sub


End Class
