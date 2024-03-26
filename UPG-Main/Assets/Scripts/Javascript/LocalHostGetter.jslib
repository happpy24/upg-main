mergeInto(LibraryManager.library, {
    GetPlayerNameFromLocalStorage: function() {
        var playerName = localStorage.getItem('name');
        if (playerName === null || playerName === undefined) {
            return "";
        } else {
            return Pointer_stringify(playerName);
        }
    }
});