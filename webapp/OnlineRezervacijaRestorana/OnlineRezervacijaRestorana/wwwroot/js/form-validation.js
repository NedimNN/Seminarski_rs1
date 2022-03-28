
$(document).ready(function () {
    $(function () {
        $("form[name='formMeal']").validate({
            rules: {
                name: "required",
                description: "required",
                price: "required"
            },
            messages: {
                name: "Please enter the name of the meal!",
                description: "Please enter the description of the meal!",
                price: "Please enter a price for the meal!"
            },
            submitHandler: function (form) {
                form.submit();
            }
        });
    });
    
});

