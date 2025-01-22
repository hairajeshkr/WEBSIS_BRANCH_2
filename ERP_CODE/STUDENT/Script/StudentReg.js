function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}




function ValidateAdd() {
    var TxtAdharNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAdharNo');
    var TxtStudentId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtStudentId');
    var DdlSaltn = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_DdlSaltn_TxtCaption");
    var TxtName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtName');


    if (!isEmpty(TxtAdharNo, 'Please enter Adhar Number.', TxtAdharNo) &&
        !isEmpty(TxtStudentId, 'Please enter Student Id.', TxtStudentId) &&
        !isEmpty(TxtName, 'Please enter Name', TxtName) &&
        !isEmpty(DdlSaltn, 'Please enter Salutation', DdlSaltn)) {
        return true;
    }
    else {
        return false;
    }
}

function restrictTo12Digits(input) {
    var value = input.value;
    // Remove non-numeric characters
    value = value.replace(/\D/g, '');
    // Limit to 12 digits
    if (value.length > 12) {
        value = value.slice(0, 12);
    }
    
    input.value = value;
}


    function calculateAge(dob) {
            if (dob && !isNaN(new Date(dob))) {
                var dobDate = new Date(dob);
    var today = new Date();

    // Calculate the age
    var age = today.getFullYear() - dobDate.getFullYear();
    var monthDiff = today.getMonth() - dobDate.getMonth();

    // Adjust if birth month or day hasn't passed
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dobDate.getDate())) {
        age--;
                }

    return age;
            }
    return '';
        }

    function attachDateChangeEvent() {
            // Attach the event handler to the date TextBox inside CtrlDate
            var dobField = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlDob_TxtDate');
    var ageField = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAge');

    if (dobField) {
        dobField.addEventListener('change', function () {
            var dob = dobField.value;
            var age = calculateAge(dob);

            // Set the calculated age in the TxtStudentAge TextBox
            ageField.value = age;
        });
            }
        }



    function attachDateChangeEventAdmisiion() {
            // Functionality for the first date control (CtrlAdmnDate)  ContentPlaceHolder1_TabContainer1_TabPanel1_TxtDate
            var admnDateTextBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlAdmnDate_TxtDate');
    var today = new Date();

    if (admnDateTextBox) {
                // Format the date as dd/MMM/yyyy
                var day = String(today.getDate()).padStart(2, '0');
    var month = today.toLocaleString('default', {month: 'short' });
    var year = today.getFullYear();

    var formattedDate = day + '/' + month + '/' + year;

    // Set the max attribute to today, formatted as dd/MMM/yyyy
    admnDateTextBox.setAttribute("data-max-date", formattedDate);

    // Disable future dates by comparing the input date with the max date
    admnDateTextBox.addEventListener('change', function () {
                    var inputDate = new Date(this.value.split('/').reverse().join('-'));
                    if (inputDate > today) {
        alert("Future dates are not allowed.");
    this.value = '';
                    }
                });
            }
        }

    // Ensure the event handler is always attached after partial page updates (postbacks)
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
        attachDateChangeEvent(); // Call the function when the page or part of the page is reloaded
    attachDateChangeEventAdmisiion();
        });

    // Attach event handler initially when the page is first loaded
    attachDateChangeEvent();
    attachDateChangeEventAdmisiion();



