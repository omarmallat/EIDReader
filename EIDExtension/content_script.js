// Listener to catch the event raised by the webpage button
document.addEventListener("EID_EVENT", function (data) {
    // send message to background process to read emirates ID and send back the data
    chrome.runtime.sendMessage("test", function (response) {
    });
});

// Listener to catch the data coming from the background process
chrome.extension.onMessage.addListener(function (msg, sender, sendResponse) {
    if (msg.action == 'EID_DATA') {
        //Parse the data and fill the form accordingly
        try {
            var json = $.parseJSON(msg.response);
            $(json).each(function (i, val) {
                $.each(val, function (key, value) {
                    if (key == 'EIDNumber')
                        $("#txtNumber").val(value);
                    if (key == 'Name')
                        $("#txtName").val(value);
                    if (key == 'Email')
                        $("#txtEmail").val(value);
                    if (key == 'PassportNumber')
                        $("#txtPassport").val(value);
                });
            });
        }
        catch (e) {
            var error = "error" + e;
        }
    }
});
