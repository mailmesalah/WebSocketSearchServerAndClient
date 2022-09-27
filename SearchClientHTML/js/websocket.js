
// the backbone of the application: the HTML5 web socket!
var socket;

/**
 * register callbacks on the socket
 */
function onOpen(e){ 
  var data = document.getElementById("textSearch").value;
  socket.send(data);    
}

function onClose(e){
}

function onMessage(e){    	
   document.getElementById("divFooter").innerHTML=e.data;   
   socket.close();
  
}
function onError(e) { 	
}

//Methods

function connectToServer(){	
	var hostIPAdd="127.0.0.1";
	var portNo="8080";
	//Connecting with server
	socket = new WebSocket("ws://"+hostIPAdd+":"+portNo);	
	socket.onopen = function(evt) { onOpen(evt) }; 
	socket.onclose = function(evt) { onClose(evt) }; 
	socket.onmessage = function(evt) { onMessage(evt) }; 
	socket.onerror = function(evt) { onError(evt) };		
}

function onClicked() { 
   connectToServer(); 
   event.preventDefault();
   return false;
}