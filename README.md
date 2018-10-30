# EIDReader
Emirates ID Reader is a tool to allow Reading Emirates ID from web applications. As of writing this document, the only applicable way to read emirates ID is to have a desktop application only. The SDK provided by Emirates ID authority included some java applet examples which will not work anymore on recent browsers.

This project is created to have a workaround only. You still have to rely on a desktop application; however, using chrome extension, you will be able to execute the desktop application in the background which read the Emirates ID data, and push it to the clipboard, then close.

After the application close, the chrome extension will read the clipboard, and send the data back to the webpage through the content_script.

Within this project, I will have:

One simple webpage that will have a button to read Emirates ID.


Chrome Extension that uses two main concepts:

1- Native Messaging where we register an application with chrome in order to call the exe.

2- ClipboardRead where we will have access to perform a "Paste" Command.


.Net Console Application to read Emirates ID data and push it to clipboard.

