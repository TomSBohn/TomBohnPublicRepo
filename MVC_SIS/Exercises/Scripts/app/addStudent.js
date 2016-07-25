$(document).ready(function() {
    $('#addStudent')
        .validate({
            rules: {
                FirstName: {
                    required: true
                },
                LastName: {
                    required: true
                },
                Major: {
                    required: true
                },
                GPA: {
                    required: true,
                    rangelength: [0, 4]
                },
                Courses: {
                    required: true
                }
            },
            messages: {
                FirstName: "Please enter your first name.",
                LastName: "Please enter your last name.",
                Major: "Select a major. You can change it later.",
                GPA: {
                    Required: "Please enter a GPA between 0 and 4.",
                    rangelength: "Nice try wise guy..."
                },
                Courses: "Please select a course."
            }
        });
})