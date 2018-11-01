# How to read Emirates ID data from web application, using JavaScript, Chrome extension, and desktop application?

Emirates ID Reader is a tool to allow Reading Emirates ID from web applications. As of writing this document, the only applicable way to read emirates ID is to have a desktop application only. The SDK provided by Emirates ID authority included some java applet examples which will not work anymore on recent browsers.

This project is created to have a workaround only. You still have to rely on a desktop application; however, using chrome extension, you will be able to execute the desktop application in the background which read the Emirates ID data, and push it to the clipboard, then close.

After the application close, the chrome extension will read the clipboard, and send the data back to the webpage through the content_script.

Within this project, I will have:

One simple webpage that will have a button to read Emirates ID.


Chrome Extension that uses two main concepts:

1- Native Messaging where we register an application with chrome in order to call the exe.

2- ClipboardRead where we will have access to perform a "Paste" Command.


For more information, check the [wiki page](https://github.com/omarmallat/EIDReader/wiki) 

> Credits: [BBCodePaste](https://github.com/jeske/BBCodePaste) for reading the clipboard.

> using Native Messging in chrome is supposed to receive data directly from the exe, instead of letting the exe push data to clipboard and then reading it. However, I faced some errors while returning values from the .net console application. As per Native Messaging documentation, I have to set the exe I/O mode to `0_BINARY` which I don't know how to do it in C#. 

