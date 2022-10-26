###### FormUDPHolePunching
 NOTE:
 This project is not completed because i decided to switch to Android (because i need 2 pc for test this instead with Android i need 2 smartphone. Much easy to carry)
 
 A project for learn how hole puncing works
 
 This project use STUN for display current machine network informations and communicate with UDP Socket to another machine
 
 This project was usefull for try to communicate between 2 machine in different networks type like on a home network (behind NAT with closed ports), on a VPS (open ports), ecc...
 
# Description
 The first thing this program do is to add a new firewall rule for let the connection work.
 After that the next step is to communicate with a STUN server for know the remote EndPoint (IP and Port) of the current machine and the nwtwork type (UdpBlocked, OpenInternet, SymmetricUdpFirewall, ecc...).
 
 After the init part has been executed the software display all the machine informations. In this way i can write them on the other software (on the Android app) for let the Android app connect to the machine.
 For complete the connection i need to do the same thing with the Android app. So i start the Android App, get the STUN info and write them in the Local EndPoint and Remote EndPoint.
 This is because if the machine is in the same network i need to connect using his local IP (usually 192.168.x.x) otherwise i need to use the remove EndPoint.
 
 When all is done i can press the "start sender" button that start to try to send packages to the destination machine (packages are just "SYN" messages)
 
 For listen to incoming messages i need to start the listener. For start it i need to put the local IP (0.0.0.0 or 127.0.0.1) on the box and press the button "Start listener".
 
 Now the machine is sending and listening for messages.
 
 Doing the same thing on the destination machine will allow the conection between the 2 machines.
 
