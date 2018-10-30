var port = null;
var tabId = null;
/* listener for messages coming from the content_scrip */
chrome.runtime.onMessage.addListener(function (message, sender, sendResponse) {
	tabId=sender.tab.id;
    var hostName = "ae.eid.chrome";
    port = chrome.runtime.connectNative(hostName);
    port.onDisconnect.addListener(onDisconnected);
});


/* THIS WILL BE CALLED ONCE EXE FINISH */
function onDisconnected() {
    port = null;
    SendResponse();
}

function SendResponse() {
    //create a textarea, focus on it, and make a "paste" command to get the clipboard, then send the pasted value back to the content_script
    bg = chrome.extension.getBackgroundPage();
    bg.document.body.innerHTML = ""; // clear the background page
    var helper = null;
    if (helper == null) {
        helper = bg.document.createElement("textarea");
        helper.style.position = "absolute";
        helper.style.border = "none";
        document.body.appendChild(helper);
    }

    //Focus the textarea
    helper.select();

    // perform a Paste in the selected control, here the textarea
    bg.document.execCommand("Paste"); 

    // Send data back to content_script
	chrome.tabs.sendMessage(tabId, { action: "EID_DATA", response: helper.value }, function (response) { });
}
