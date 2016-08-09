﻿function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'First Name should not be empty';
    } else {
        return "";
    }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1) {
        return 'First Name should not contain @';
    } else {
        return "";
    }
}

function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length >= 15) {
        return 'Last Name should not contain more than 15 character.';
    } else {
        return "";
    }
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == "") {
        return 'Salary should not be empty.';
    } else {
        return "";
    }
}
function IsSalaryInValid() {
    if (!document.getElementById('TxtSalary').value) {
        return 'Enter valid salary';
    } else {
        return "";
    }
}

function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInValidMessage = IsFirstNameInValid();
    var LastNameInValidMessage = IsLastNameInValid();
    var SalaryEmptyMessage = IsSalaryEmpty();
    var SalaryInValidMessage = IsSalaryInValid();

    var FinalErrorMessage = "Errors:";
    
    if (FirstNameEmptyMessage != "") {
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    }
    if (FirstNameInValidMessage != "") {
        FinalErrorMessage += "\n" + FirstNameInValidMessage;
    }
    if (LastNameInValidMessage != "") {
        FinalErrorMessage += "\n" + LastNameInValidMessage;
    }
    if (SalaryEmptyMessage != "") {
        FinalErrorMessage += "\n" + SalaryEmptyMessage;
    }
    if (SalaryInValidMessage != "") {
        FinalErrorMessage += "\n" + SalaryInValidMessage;
    }
    
    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    } else {
        return true;
    }
}