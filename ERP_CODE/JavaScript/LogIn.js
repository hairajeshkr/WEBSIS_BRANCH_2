function ValidateMasterData()  
{
    var TxtUserName = document.getElementById('TxtUserName');
    var TxtPwd = document.getElementById('TxtPwd');
    
    if(!isEmpty(TxtUserName,'Please enter user name.',TxtUserName) && 
            !isEmpty(TxtPwd,'Please enter passwod.',TxtPwd))
        {
            return true;
        }
        else
        {
            return false;
        }
}
/*============================= DropdownList Box Binding ============================*/

function FnDropdownListBindScript()
{
    var TxtUserName = document.getElementById('TxtUserName').value;
    var TxtPwd = document.getElementById('TxtPwd').value;
    
    var DdlBranch = document.getElementById('DdlBranch').id;
    var DdlFYear = document.getElementById('DdlFYear').id;   
    //call server side method 
    PageMethods.FnJsLocation_DropDownList(TxtUserName,TxtPwd,ValDropDownSuccess,ValFailed,DdlBranch);

    PageMethods.FnJsFaYear_DropDownList(TxtUserName,TxtPwd,ValDropDownSuccess,ValFailed,DdlFYear); 
}