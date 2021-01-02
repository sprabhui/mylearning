/** browser dependent definition are aligned to one and the same standard name **/
navigator.getUserMedia = navigator.getUserMedia || navigator.mozGetUserMedia || navigator.webkitGetUserMedia;
window.RTCPeerConnection = window.RTCPeerConnection || window.mozRTCPeerConnection || window.webkitRTCPeerConnection;
window.RTCIceCandidate = window.RTCIceCandidate || window.mozRTCIceCandidate || window.webkitRTCIceCandidate;
window.RTCSessionDescription = window.RTCSessionDescription || window.mozRTCSessionDescription || window.webkitRTCSessionDescription;
window.SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition || window.mozSpeechRecognition 
  || window.msSpeechRecognition || window.oSpeechRecognition;

var localVideo = null, 
  localVideoStream = null,
  recordButton = null;
var recordedChunks = [];
var mediaRecorder;
var serverUrl = "https://localhost";


function pageReady() {
  // check browser WebRTC availability 
  if(navigator.getUserMedia) {
    recordButton = document.getElementById("recordButton");    
    localVideo = document.getElementById('localVideo');      
  } else {
    alert("Sorry, your browser does not support WebRTC!")
  }
};

// run start(true) to initiate a call
function recordit() {  
  // get the local stream, show it in the local video element and send it
  navigator.getUserMedia({ "audio": true, "video": true }, function (stream) {
    localVideoStream = stream;
    localVideo.srcObject = localVideoStream;    
	
	var options = {mimeType: 'video/webm;codecs=vp8'};
    mediaRecorder = new MediaRecorder(stream, options);
	mediaRecorder.ondataavailable = handleDataAvailable;
	mediaRecorder.start(5000);
	
  }, function(error) { console.log(error);});
};

function handleDataAvailable(event) {
  if (event.data && event.data.size > 0) {
        fetch(serverUrl + '/video-chunck/123', {
            method: 'POST',
            headers: {'Content-Type': 'application/octet-stream'},
            body:event.data
        });
    }
}

function stopit()
{
	mediaRecorder.stop();
}
