window.theme = {
    toggleDark: function () {
        const isDark = document.documentElement.classList.toggle("dark");
        localStorage.setItem("darkMode", isDark);
        return isDark;
    },

    setDark: function (isDark) {
        document.documentElement.classList.toggle("dark", isDark);
        localStorage.setItem("darkMode", isDark);
    },

    getDark: function () {
        return localStorage.getItem("darkMode") === "true";
    }
};

window.culture = {
    set: function (lang) {
        localStorage.setItem("culture", lang);

        document.cookie =
            `.AspNetCore.Culture=c=${lang}|uic=${lang}; path=/`;

        location.reload();
    },

    get: function () {
        return localStorage.getItem("culture") || "en";
    }
};