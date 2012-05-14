$(function () {
    var post = function (elem) {
        var form = $(elem).parents("form");
        if ($(elem).hasClass("ajax")) {
            $.post(
                $(elem).attr("href"),
                form.serialize(),
                function (html) {
                    form.replaceWith(html);
                }
            );
        }
        else {
            form.attr("action", $(elem).attr("href"));
            form.submit();
        }
        return false;
    };

    $("body").on("click", "a.postLink", function () {
        return post(this);
    });
    $("body").on("change", "select.postLink", function () {
        return post(this);
    });
    $("body").on("change", "input.postLink", function () {
        return post(this);
    });
});