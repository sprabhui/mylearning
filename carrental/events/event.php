<?php
include_once("db_connect.php");
$sqlEvents = "SELECT id, BookingNumber,userEmail,FromDate, ToDate FROM tblbooking where VehicleId=".$_GET["vid"]." and Status=1 LIMIT 20";
$resultset = mysqli_query($conn, $sqlEvents) or die("database error:". mysqli_error($conn));
$calendar = array();
while( $rows = mysqli_fetch_assoc($resultset) ) {	
	// convert  date to milliseconds
	$start = strtotime($rows['FromDate']) * 1000;
	$end = strtotime($rows['ToDate']) * 1000;	
	$calendar[] = array(
        'id' =>$rows['id'],
        'title' => 'Booked for '.$rows['userEmail'].' with Booking No: '.$rows['BookingNumber'],
        'url' => "#",
		"class" => 'event-important',
        'start' => "$start",
        'end' => "$end"
    );
}
$calendarData = array(
	"success" => 1,	
    "result"=>$calendar);
echo json_encode($calendarData);
exit;
?>