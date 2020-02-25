(function () {

    // ┌─────────────┐
    // │ File Upload │
    // └─────────────┘

    handleFileSelect = function (event) {
        if (window.File && window.FileList && window.FileReader) {

            var files = event.target.files;

            for (var i = 0; i < files.length; i++) {
                var file = files[i];

                // Only image uploads supported
                if (!file.type.match('image'))
                    continue;

                var reader = new FileReader();
                reader.addEventListener("load", function (event) {
                    var image = new Image();
                    image.alt = file.name;
                    image.onload = function (e) {
                        image.setAttribute("data-filename", file.name);
                        image.setAttribute("width", image.width);
                        image.setAttribute("height", image.height);
                        tinymce.activeEditor.execCommand('mceInsertContent', false, image.outerHTML);
                    };
                    image.src = this.result;

                });

                reader.readAsDataURL(file);
            }

            document.body.removeChild(event.target);
        }
        else {
            console.log("Your browser does not support File API");
        }
    }

    // ┌───────────────┐
    // │ Delete Post B │
    // └───────────────┘

    deletePostB = function (elm, id, callback) {
        debugger;

        var r = confirm("The post will be deleted. Do you want to continue ?");
        if (r == true) {
            var serviceURL = '/Blog/DeletePostB/' + id;
            $.ajax({
                type: 'Post',
                cache: false,
                url: serviceURL,
                dataType: "json",
                error: function (result) {
                    alert("error");
                },
                success: function (data) {
                    if (data.deleted)
                        callback(elm);
                }
            });
        }
    }

    callbackToList = function()
    {
        window.location.href = '/blog';
    }

    callbackRemove = function(elm)
    {
        $(elm).CardWidget('remove');
    }

    // ┌─────────────────┐
    // │ Delete Comments │
    // └─────────────────┘

    var deleteLinks = document.querySelectorAll("#comments a.delete");
    if (deleteLinks) {
        for (var i = 0; i < deleteLinks.length; i++) {
            var link = deleteLinks[i];

            link.addEventListener("click", function (e) {
                if (!confirm("Are you sure you want to delete the comment?")) {
                    e.preventDefault();
                }
            });
        }
    }

})();