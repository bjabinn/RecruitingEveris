$(document).ready(function () {
    //Sidebar Accordion Menu:

    $("#main-nav li ul").hide(); // Hide all sub menus
    $("#main-nav li a.current").parent().find("ul").slideToggle("slow"); // Slide down the current menu item's sub menu

    //Events
    $("#main-nav li a.nav-top-item").click( // When a top menu item is clicked...
        function () {
            var source = $(this);
            var allTopMenu = $("#main-nav li a.nav-top-item");
            allTopMenu.removeClass("current");

            source.parent().siblings().find("ul").slideUp("normal"); // Slide up all sub menus except the one clicked
            source.next().slideToggle("normal"); // Slide down the clicked sub menu
            source.addClass("current");
            return false;
        }
    );

    $("#main-nav li a.no-submenu").click( // When a menu item with no sub menu is clicked...
        function () {
            window.location.href = (this.href); // Just open the link instead of a sub menu
            return false;
        }
    );

    // Sidebar Accordion Menu Hover Effect:

    $("#main-nav li .nav-top-item").hover(
        function () {
            $(this).stop().animate({ paddingRight: "25px" }, 200);
        },
        function () {
            $(this).stop().animate({ paddingRight: "15px" });
        }
    );

    //Close button:
    //TODO pgarciaq: Esto tiene pinta de que no es del menu...
    $(".close").click(
        function () {
            $(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
                $(this).slideUp(400);
            });
            return false;
        }
    );
});



function resetFields(form) {
    $(':input', form).each(function () {
        var type = this.type;
        var tag = this.tagName.toLowerCase(); // normalize case
        // to reset the value attr of text inputs,
        // password inputs, fileUpload and textareas
        if (type == 'text' || type == 'password' || tag == 'textarea' || type == 'file')
            this.value = "";
            // checkboxes and radios need to have their checked state cleared                
        else if (type == 'checkbox' || type == 'radio')
            this.checked = false;
            // select elements need to have their 'selectedIndex' property set to -1
            // (this works for both single and multiple select elements)
        else if (tag == 'select')
            this.selectedIndex = 0;
    });
}