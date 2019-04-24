var loadCallbacks = new Array();
var loadExecutingCallbacks = false;

function loadRegisterCallback(callbackFunction) {
    loadCallbacks.push(callbackFunction);
}

function loadRunCallbacks() {
    if (!loadExecutingCallbacks) {
        loadCallbacks.reverse();
    }

    loadExecutingCallbacks = true;

    while (loadCallbacks.length > 0) {
        loadCallbacks.pop()();
    }

    loadExecutingCallbacks = false;
}
