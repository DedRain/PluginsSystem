function Global() {

    this.StatusPanel = {
        CurrentUser: {
            labelControlID: "CurrentUserLabel",
            loginControlID: "LogInLogOutButton"
        },
        controlID: "StatusPanel"
    };
}

window.Global = new Global();