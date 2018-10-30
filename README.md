# EIDReader
Emirates ID Reader is a tool to allow Reading Emirates ID from web applications. as of writing this, the only applicable way to read emirates ID is to have a desktop application only. the SDK provided by Emirates ID authority included some java applet examples which will not work anymore on recent browsers.

This project is created to have a workaround only. You still have to rely on a desktop application; however, using chrome extension, you will be able to execute the desktop application. the application will actually, read the Emirates ID data, and copy it to the clipboard, then close.

after the application close, the chrome extension will read the clipboard, and send the data back to the webpage through the content_script.

within this project, I will use two main concepts:

1- Native Messaging where we register an application with chrome in order to call the exe.

2- ClipboardRead where we will have access to perform a "Paste" Command.

Both concepts require to have a background process in the extension.
