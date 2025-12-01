$.validator.addMethod('dhlRequired', function (value, element) {
    switch (typeof (value)) {
        case 'object': {
            if (value.length > 0) {
                return true;
            }
            break;
        }

        default: {
            if (value.trim() !== '') {
                return true;
            };
            break;
        }
    }

    return false;

}, function (params, element) {
    if ($(element).data('error-message') != undefined) {
        return $(element).data('error-message');
    }
    else {
        var displayName = $(element).data('display-name') != undefined ? $(element).data('display-name') : $(element).attr('id')
        return displayName + ' không được để trống.';
    }
});

$.validator.addMethod("dhlCheckCKEditorRequired",
    function (value, element) {
        return checkCKEditor();
    }, function (params, element) {
        if ($(element).data('error-message') != undefined) {
            return $(element).data('error-message');
        }
        else {
            var displayName = $(element).data('display-name') != undefined ? $(element).data('display-name') : $(element).attr('id')
            return displayName + ' không được để trống.';
        }
    }
);

function checkCKEditor() {
    //if (CKEDITOR.instances.content_body.getData() == '') {
    //    return false;
    //}
    //else {
    //    $("#error_check_editor").empty();
    //    return true;
    //}

    return true;
}

$.validator.defaults.errorElement = "span";
$.validator.defaults.errorClass = "validation-error";
$.validator.prototype.showLabel = function (element, message) {
    var place, group, errorID, v,
        error = this.errorsFor(element),
        elementID = this.idOrName(element),
        describedBy = $(element).attr("aria-describedby");

    if (error.length) {

        // Refresh error/success class
        error.removeClass(this.settings.validClass).addClass(this.settings.errorClass);

        // Replace message on existing label
        error.html(message);
    } else {

        // Create error element
        error = $("<" + this.settings.errorElement + ">")
            .attr("id", elementID + "-error")
            .addClass(this.settings.errorClass)
            .html(message || "");

        // Maintain reference to the element to be placed into the DOM
        place = error;
        if (this.settings.wrapper) {

            // Make sure the element is visible, even in IE
            // actually showing the wrapped element is handled elsewhere
            place = error.hide().show().wrap("<" + this.settings.wrapper + "/>").parent();
        }
        if (this.labelContainer.length) {
            this.labelContainer.append(place);
        } else if (this.settings.errorPlacement) {
            this.settings.errorPlacement.call(this, place, $(element));
        } else {
            if (element.nodeName == "SELECT") {
                var parent = element.closest("div");
                $(parent).append(place);
            }
            else {
                place.insertAfter(element);
            }
        }

        // Link error back to the element
        if (error.is("label")) {

            // If the error is a label, then associate using 'for'
            error.attr("for", elementID);

            // If the element is not a child of an associated label, then it's necessary
            // to explicitly apply aria-describedby
        } else if (error.parents("label[for='" + this.escapeCssMeta(elementID) + "']").length === 0) {
            errorID = error.attr("id");

            // Respect existing non-error aria-describedby
            if (!describedBy) {
                describedBy = errorID;
            } else if (!describedBy.match(new RegExp("\\b" + this.escapeCssMeta(errorID) + "\\b"))) {

                // Add to end of list if not already present
                describedBy += " " + errorID;
            }
            $(element).attr("aria-describedby", describedBy);

            // If this element is grouped, then assign to all elements in the same group
            group = this.groups[element.name];
            if (group) {
                v = this;
                $.each(v.groups, function (name, testgroup) {
                    if (testgroup === group) {
                        $("[name='" + v.escapeCssMeta(name) + "']", v.currentForm)
                            .attr("aria-describedby", error.attr("id"));
                    }
                });
            }
        }
    }
    if (!message && this.settings.success) {
        error.text("");
        if (typeof this.settings.success === "string") {
            error.addClass(this.settings.success);
        } else {
            this.settings.success(error, element);
        }
    }
    this.toShow = this.toShow.add(error);
}