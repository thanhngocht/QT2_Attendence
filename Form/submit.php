<?php
// Kết nối đến cơ sở dữ liệu SQL Server
$serverName = "IIV\SQLEXPRESS"; // Thay đổi với tên máy chủ của bạn
$connectionOptions = array("Database" => "DiemDanh");
;
// Kết nối đến cơ sở dữ liệu
$conn = sqlsrv_connect($serverName, $connectionOptions);
if ($conn === false) {
    die(print_r(sqlsrv_errors(), true));
}

// Nhận dữ liệu từ request
$data = json_decode(file_get_contents("php://input"), true);
$studentId = $data['StudentId'];
$attendanceId = $data['AttendanceId'];
$ipAddress = $data['LocalIPAddress']; // Lấy địa chỉ IP
$gpsCoordinates = $data['GPSCoordinates'];

// Kiểm tra mã điểm danh có tồn tại và thời gian không quá 20 giây
// Thiết lập múi giờ cho PHP (thay đổi múi giờ theo nhu cầu của bạn)
date_default_timezone_set('Asia/Ho_Chi_Minh'); // Ví dụ: múi giờ Việt Nam
$sqlCheckAttendance = "SELECT * FROM TeacherQRData WHERE QRCode = ?";
$paramsCheckAttendance = array($attendanceId);
$stmtCheckAttendance = sqlsrv_query($conn, $sqlCheckAttendance, $paramsCheckAttendance);

if ($stmtCheckAttendance === false) {
    die(print_r(sqlsrv_errors(), true));
}

$rowAttendance = sqlsrv_fetch_array($stmtCheckAttendance, SQLSRV_FETCH_ASSOC);
if ($rowAttendance) {
    $createdAt = $rowAttendance['CreatedAt'];
    // Lấy thời gian hiện tại
    $currentTime = new DateTime();

     // Tính khoảng thời gian giữa thời gian hiện tại và CreatedAt
    $timeDiff = $currentTime->diff($createdAt);
    if ($timeDiff->s > 20 || $timeDiff->i > 0 || $timeDiff->h > 0 || $timeDiff->d > 0) {
        echo json_encode(array("Message" => "Thời gian giữa mã điểm danh và thời điểm hiện tại đã quá 15 giây!".$timeDiff->format('%h giờ %i phút %s giây')));
        exit;
    }
} 

// Kiểm tra địa chỉ IP đã tồn tại chưa
$sqlCheckIP = "SELECT COUNT(*) AS IPCount FROM StudentUploads WHERE LocalIPAddress = ?";
$paramsCheckIP = array($ipAddress);
$stmtCheckIP = sqlsrv_query($conn, $sqlCheckIP, $paramsCheckIP);
$rowIP = sqlsrv_fetch_array($stmtCheckIP, SQLSRV_FETCH_ASSOC);
if ($rowIP['IPCount'] > 0) {
    echo json_encode(array("Message" => "Địa chỉ IP đã được sử dụng!"));
    exit;
}



// Hàm tính khoảng cách giữa hai tọa độ GPS
function haversineGreatCircleDistance($latitudeFrom, $longitudeFrom, $latitudeTo, $longitudeTo, $earthRadius = 6371) {
    // Chuyển đổi từ độ sang radian
    $latFrom = deg2rad($latitudeFrom);
    $lonFrom = deg2rad($longitudeFrom);
    $latTo = deg2rad($latitudeTo);
    $lonTo = deg2rad($longitudeTo);

    // Tính khoảng cách
    $latDelta = $latTo - $latFrom;
    $lonDelta = $lonTo - $lonFrom;
    $a = sin($latDelta / 2) * sin($latDelta / 2) +
         cos($latFrom) * cos($latTo) *
         sin($lonDelta / 2) * sin($lonDelta / 2);
    $c = 2 * atan2(sqrt($a), sqrt(1 - $a));

    return $earthRadius * $c; // Đơn vị km
}

// Chuẩn bị câu lệnh SQL để chèn dữ liệu
$sql = "INSERT INTO StudentUploads (StudentId, LocalIPAddress, GPSCoordinates) VALUES (?, ?, ?)";
$params = array($studentId, $ipAddress, $gpsCoordinates);

// Thực thi câu lệnh
$stmt = sqlsrv_query($conn, $sql, $params);
if ($stmt === false) {
    die(print_r(sqlsrv_errors(), true));
}

// Hiển thị thông tin đã nhận
echo json_encode(array(
    "StudentId" => $studentId,
    "LocalIPAddress" => $ipAddress,
    "GPSCoordinates" => $gpsCoordinates,
    "Message" => "Thành công!"
));

// Đóng kết nối
sqlsrv_free_stmt($stmt);
sqlsrv_close($conn);
?>