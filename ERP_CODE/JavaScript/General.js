
function FnGetPopUp(PrmURL, PrmHeader, PrmWidth, PrmHeight) {
    var ReportWinChld = dhtmlwindow.open('ReportWinChld', 'iframe', PrmURL, PrmHeader, 'width=' + PrmWidth + 'px,height=' + PrmHeight + 'px,resize=0,scrolling=0,center=1', 'recal');
}
function FnGetPopUpSub(PrmURL, PrmHeader, PrmWidth, PrmHeight) {
    var ReportWinChldSub = dhtmlwindow.open('ReportWinChldSub', 'iframe', PrmURL, PrmHeader, 'width=' + PrmWidth + 'px,height=' + PrmHeight + 'px,resize=0,scrolling=0,center=1', 'recal');
}
function FnGetPopUpValidate(PrmURL, PrmHeader, PrmWidth, PrmHeight) {
    var ReportWinVal = dhtmlwindow.open('ReportWinVal', 'iframe', PrmURL, PrmHeader, 'width=' + PrmWidth + 'px,height=' + PrmHeight + 'px,resize=0,scrolling=0,center=1', 'recal');
    ReportWinVal.onclose = function () {
        return window.confirm('Do you want to close this window?')
    }
}
function FnGetPopUpValidateWindow(PrmURL, PrmHeader, PrmWidth, PrmHeight) {
    var ReportWinVal = dhtmlwindow.open('ReportWinVal', 'iframe', PrmURL, PrmHeader, 'width=' + PrmWidth + 'px,height=' + PrmHeight + 'px,resize=0,scrolling=0,center=1', 'recal');
    ReportWinVal.onclose = function () {
        if (FnValidateChildPage() == true) {
            return window.confirm('Do you want to close this window?')
        }
        return false;
    }
}
function FnChangeRowColor(PrmCtrl,row)
{
    var previousRow = document.getElementById(PrmCtrl).value;
    if (previousRow == '') {
        previousRow = null;
    }
    if (previousRow == row)
        return;
    else if (previousRow != null)
        document.getElementById(previousRow).style.backgroundColor = "Yellow";
    document.getElementById(row).style.backgroundColor = "#FFC0FF";
    document.getElementById(PrmCtrl).value = row;
}
// Coommon function are stored in this form.
function GetChkRadValue(ChkBoxId,msg,fldFocus)
{
   var flag=0;
   var chkList1= ChkBoxId;
   var arrayOfCheckBoxes= chkList1.getElementsByTagName("input");
   var lenght=arrayOfCheckBoxes.length;    
   for(counter = 0; counter<arrayOfCheckBoxes.length; counter++)
   {
       if (arrayOfCheckBoxes[counter].checked)
       {
          flag=1;
       } 
   }
   if(flag==0)
   {
        alert(msg);
		fldFocus.focus();
		return false;
   }
   return true;
}
function FnIsNumeric(strString)
{
    var strValidChars = "0123456789.-";
    var strChar;
    var blnResult = true;
    if (strString.length == 0) return 0;
        //  test strString consists of valid characters listed above
    for (i = 0; i < strString.length && blnResult == true; i++)
    {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1)
        {
            blnResult = false;
        }
    }
    var dVal=0;
    if(blnResult==true)
    {
        dVal=parseFloat(strString);
    }
    return dVal;
}
function FnGetRadBtnSelectedValue(PrmCtrlRadBtn)
{
   var strVal="";
   var radio = PrmCtrlRadBtn.getElementsByTagName("input");
   var label = PrmCtrlRadBtn.getElementsByTagName("label");
   for (var i=0;i<radio.length;i++)
   {
       if (radio[i].checked)
       {
           /*alert("SelectedText = " + label[i].innerHTML);*/
           strVal= radio[i].value;
       }
   }
   return strVal;
}
function isEmpty(field,msg,fldFocus)
{
	if(isBlank(field.value))
	{
		alert(msg);
		fldFocus.focus();
		fldFocus.select();
		return true;
	}
	return false;
}
function FnRow(PrmIndex)
{
    if(PrmIndex<=9)
    {
        return "0" + PrmIndex;
    }
    return PrmIndex;    
}
function isAssignZero(field,fldFocus)
{
	if(isBlank(field.value))
	{
		field.value=0;
		fldFocus.focus();
		fldFocus.select();
		return true;
	}
	return false;
}
//check if a string is all its characters blank 
function isBlank(str)
{
	if(str=='' || str.length==0) return true;
	for(i=0;i<str.length;i++)
	 if (str.charAt(i)!=' ') return false;
	return true;
}
function isListSelected(field,msg,fldFocus,indx)
{
	if(field.selectedIndex == indx) 
	{
		alert(msg);
		fldFocus.focus();
		return false;
	} else 
	{
		return true
	}
}
function isChildData(field,msg,fldFocus)
{
	if(field.value <= 0)
	{
		alert(msg);
		fldFocus.focus();
		//fldFocus.select();
		return false;
	}
	return true;
}
function isZeroVlaue(field,msg,fldFocus)
{
	if(field.value <= 0)
	{
		alert(msg);
		fldFocus.focus();
		fldFocus.select();
		return false;
	}
	return true;
}
function isCheckMobileNo(field, msg, fldFocus) {
    if (FnIsNumeric(field.value) <= 1111111111 || FnIsNumeric(field.value) > 9999999999)
    {
        alert(msg);
        fldFocus.focus();
        fldFocus.select();
        return false;
    }
    return true;
}
function isMultiplyVlaue(FrmField,ToField,SubmitFld)
{
alert(FrmField.value);
//    var dVal=FrmField.value * ToField.value;
//    SubmitFld.value=dVal;
}
function isListCount(field,msg,fldFocus)
{
	if(field.length <= 0)
	{
		alert(msg);
		fldFocus.focus();
		fldFocus.select();
		return false;
	}
	return true;
}
function isLessthanVlaue(FrmField,ToField,msg)
{
    var iFrmValue;
    iFrmValue=parseFloat(FrmField.value.trim());
    var iToValue;
    iToValue=parseFloat(ToField.value.trim());
    //alert(" To :" + iToValue + " , From:" + iFrmValue)
	if(iFrmValue < iToValue )
	{
		alert(msg);
		ToField.focus();
		ToField.select();
		return false;
	}
	return true;
}
function isLessthanEqualVlaue(PrmFrmValue,PrmToValue,PrmToField,msg)
{
    var iFrmValue;
    iFrmValue=parseFloat(PrmFrmValue);
    var iToValue;
    iToValue=parseFloat(PrmToValue);
	if(iFrmValue < iToValue )
	{
		alert(msg);
		PrmToField.focus();
		PrmToField.select();
		return false;
	}
	return true;
}
function isNotEqualTo(FrmField,ToField,msg)
{
    var iFrmValue;
    iFrmValue=FnIsNumeric(FrmField.value.trim());
    var iToValue;
    iToValue=FnIsNumeric(ToField.value.trim());
    //alert(" To :" + iToValue + " , From:" + iFrmValue)
	if(iFrmValue != iToValue )
	{
		alert(msg);
		return false;
	}
	return true;
}
function isGreaterThanVlaue(FrmField,ToField,msg)
{
    var iFrmValue;
    iFrmValue=parseFloat(FrmField.value.trim());
    var iToValue;
    iToValue=parseFloat(ToField.value.trim());
	if(iFrmValue > iToValue )
	{
		alert(msg);
		ToField.focus();
		ToField.select();
		return false;
	}
	return true;
}
function isGreaterThanToValue(FrmField, ToField, msg) {
    var iFrmValue;
    iFrmValue = parseFloat(FrmField.value.trim());
    var iToValue;
    iToValue = parseFloat(ToField.value.trim());

    if (iFrmValue < iToValue) {
        alert(msg);
        ToField.focus();
        ToField.select();
        return false;
    }
    return true;
}
function IsValidateDate(field,msg)
{    
    var sDate=field.value;
    var arrDate=sDate.split("/");
    var Day=arrDate[0];
    var Mn=arrDate[1];
    var Yr=arrDate[2];
    var DateVal = FnGetMonth(Mn) + "/" + Day + "/" + Yr;
    var dt = new Date(DateVal);
    if(dt.getDate()!=Day)
    {
        alert(msg);//+"Day");
        field.focus();
        field.select();
        return(false);
    }
    else if(dt.getMonth()!=FnGetMonth(Mn)-1)
    {
       //this is for the purpose JavaScript starts the month from 0
        alert(msg);//+"Month");
        field.focus();
        field.select();
        return(false);
    }
    else if(dt.getFullYear()!=Yr)
    {
        alert(msg);//+"Year");
        field.focus();
        field.select();
        return(false);
    }
    return(true);
}
function FnGetMonth(StrMonth)
{
    switch (StrMonth)
    {
         case "Jan":
             return 1;
             break;
         case "Feb":
             return 2;
             break;
         case "Mar":
             return 3;
             break;
         case "Apr":
             return 4;
             break;
         case "May":
             return 5;
             break;
         case "Jun":
             return 6;
             break;
         case "Jul":
             return 7;
             break;
         case "Aug":
             return 8;
             break;  
         case "Sep":
             return 9;
             break;
         case "Oct":
             return 10;
             break;
         case "Nov":
             return 11;
             break;
         case "Dec":
             return 12;
             break;   
    }
}
//===============  Key press validation script
function NumbersOnly(e)
{
    var unicode=e.charCode? e.charCode : e.keyCode
    //alert(unicode);
    if (unicode!=8 || unicode !=13)
    {   //if the key isn't the backspace key (which we should allow)
        if (unicode==13)
        {
            return true;
        }
        else if (unicode==8 || unicode==9)
        {
            return true;
        }
        else if (unicode >=96 && unicode <=105)
        {
            return true;
        }
        else if (unicode<48||unicode>57)
        { 
            //if not a number
            return false //disable key press
        }
    }
}
function IsReadOnly(e)
{
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode == 9) {
        return true;
    }
    else {
        return false;
    }
}
function CharOnly(e)
{
    var unicode=e.charCode? e.charCode : e.keyCode
    //alert(unicode);
    if (unicode!=8 || unicode !=13)
    {   //if the key isn't the backspace key (which we should allow)
        if (unicode==13)
        {
            return true;
        }
         else if (unicode==8)
        {
            return true;
        }
        else if (unicode<48||unicode>57)
        { 
            //if not a number
            return true; //Enable key press
        }
        return false;
    }
}
function IsDecimal(e,Ctrl) 
{
    var StrChar;
    var sText=document.getElementById(Ctrl).value;
    var i;
    var unicode=e.charCode? e.charCode: e.keyCode;
    var flag=0,flagm=0;
    for ( i = 0;i < sText.length ; i++) 
    { 
        StrChar = sText.charAt(i); 
        if (StrChar ==".")
        {
            flag=1;
            break;
        }
        if (StrChar =="-")
        {
            flagm=1;
            break;
        }
    }
    if (unicode==13 || unicode==9 || unicode==8 || unicode==45|| unicode==36 || unicode==35 || unicode==110 || unicode==109 )
    {
        return true;
    }
    else if (unicode >=96 && unicode <=105)
    {
        return true;
    }
    else if (unicode < 48 ||unicode > 57)
    {
        if (unicode==46 && flag==0)
        {
            return true;  
        }
        if((unicode==189 || unicode==190) && (flag==0 || flagm==0))
        {
            return true;
        }
        return false;
    }
}
function onSaveButtonClick(e,Ctrl,CtrlSave) 
{
    var unicode=e.charCode? e.charCode : e.keyCode
    //alert(unicode);
     if (unicode==13)
      {
         document.getElementById('ctl00_ContentPlaceHolder1_' + Ctrl).click();
         return false;
      }
//      if (unicode==121)
//      {
//         document.getElementById('ctl00_ContentPlaceHolder1_' + CtrlSave).click();
//         return false;
//      }
}
function onSaveButtonClick(e, Ctrl)
{
    var unicode = e.charCode ? e.charCode : e.keyCode
     if (unicode == 13)
     {
        document.getElementById(Ctrl).click();
        return false;
    }
}
function FnFocusControl(e,Ctrl) 
{
 var unicode=e.charCode? e.charCode : e.keyCode;
 if (unicode==13)
  {
     document.getElementById(Ctrl).focus();
     document.getElementById(Ctrl).select();
     return false;
  }
}
function onButtonClick(e,Ctrl) 
{
    var unicode=e.charCode? e.charCode : e.keyCode
    //alert(unicode);
     if (unicode==13)
      {
         document.getElementById('ctl00_ContentPlaceHolder1_' + Ctrl).click();
         return true;
      }
}
function onSinglePageButtonClick(e,Ctrl) 
{
    var unicode=e.charCode? e.charCode : e.keyCode
    //alert(unicode);
     if (unicode==13)
      {
       //alert(document.getElementById(Ctrl).id);
         document.getElementById(Ctrl).click();
         return true;
      }
}
function IsSelect(fldFocus)
{
    fldFocus.focus();
    fldFocus.select();
    return true;
}
function FnClearListCtrl(PrmListCtrl)
{
    var LstChrg = document.getElementById(PrmListCtrl);
    var iLen=LstChrg.options.length;
    for(i=iLen-1;i>=0;i--)
    {
       LstChrg.remove(i);
    }
}
function ChangeInsideCaption()
{
    var ChkTranSide = document.getElementById('ctl00_ContentPlaceHolder1_ChkTranSide');
    if(ChkTranSide.checked=true)
    {
        //ChkTranSide.value="Inside";
        alert( ChkTranSide.value);
    }
    else
    {
     ChkTranSide.value="Outside";
        //alert("Unchecked.");
    }
    return true;
}
function FnCheckFaYearTrDate(field)
{
    var TxtTrDate =field;// document.getElementById('ctl00_ContentPlaceHolder1_TxtTrDate');
    var HdnFrmDate =document.getElementById('HdnFrmDate').value;
    var HdnToDate =document.getElementById('HdnToDate').value;
    var HdnDate =document.getElementById('HdnDate').value;
    var arrDate=TxtTrDate.value.split("/");
    var Day=arrDate[0];
    var Mn=arrDate[1];
    var Yr=arrDate[2];
    var DateVal =Yr + "/" + FnGetMonth(Mn)+ "/" + Day;    
    var CurntDateVal =new Date(DateVal);

    var FrmDate=HdnFrmDate.split("/");
    var FDay=FrmDate[0];
    var FMn=FrmDate[1];
    var FYr=FrmDate[2];
    var DateFrmVal =FYr + "/" + FnGetMonth(FMn)+ "/" + FDay;    
    var dateFrom =new Date(DateFrmVal);

    var ToDate=HdnToDate.split("/");
    var TDay=ToDate[0];
    var TMn=ToDate[1];
    var TYr=ToDate[2];
    var DateToVal =TYr + "/" + FnGetMonth(TMn)+ "/" + TDay;    
    var dateTo =new Date(DateToVal);
    //alert(HdnToDate + " Current Date : " + DateVal);
 
    var dateCr = new Date(HdnDate);
    if(dateCr < CurntDateVal)
    {
      alert("Transaction date could not allow posted date."); 
      return false;
    }
    if(dateFrom <=CurntDateVal && dateTo >= CurntDateVal)
    {
      return true;
    }
    else
    {
        alert("Transaction date must be select current financial year."); /**/
        return false;
    }
}
function FnCompaireTwoDate(PrmFromDate,PrmToDate,PrmMsg)
{
    var arrFrmDate=PrmFromDate.value.split("/");
    var FrmDay=arrFrmDate[0];
    var FrmMn=arrFrmDate[1];
    var FrmYr=arrFrmDate[2];  
    var FromDate=FrmYr +  "/" + FnGetMonth(FrmMn) +  "/" + FrmDay;

    var ToDate =PrmToDate;
    var arrDate=ToDate.value.split("/");
    var Day=arrDate[0];
    var Mn=arrDate[1];
    var Yr=arrDate[2];
    var DateVal =Yr + "/" + FnGetMonth(Mn)+ "/" + Day;
    var CurntDateVal =new Date(DateVal);
    
    //alert("From Date :" + FromDate);
    var dateFrom = new Date(FromDate); 
    //alert(dateFrom + " Current Date : " + CurntDateVal);
    if(dateFrom <=CurntDateVal)
    {
      return true;
    }
    else
    {
        alert(PrmMsg); 
        PrmToDate.focus();
        return false;
    }
}
function FnIsDecimal(objValue)
{
    var charpos = objValue.search("[^''-.-0-9]"); 
    var dVal=objValue;
    if(objValue.length > 0 &&  charpos >= 0) 
    { 
        dVal=0;
    }
    return dVal;
}
function FnGetDoubleVal(PrmVal)
{
    var dVal = 0.00;

    if (PrmVal == '') {
        dVal = 0;
    }
    else {
        dVal = parseFloat(PrmVal);
    }
    return dVal;
}
//======================================  Tree view Check box Check / Uncheck

function OnTreeClick(evt) 
{
var src = window.event != window.undefined ? window.event.srcElement : evt.target;
var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
if (isChkBoxClick) {
var parentTable = GetParentByTagName("table", src);
var nxtSibling = parentTable.nextSibling;
if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
{
    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
    {
        //check or uncheck children at all levels
        CheckUncheckChildren(parentTable.nextSibling, src.checked);
    }
}
//check or uncheck parents at all levels
CheckUncheckParents(src, src.checked);
}
}
function CheckUncheckChildren(childContainer, check) 
{
var childChkBoxes = childContainer.getElementsByTagName("input");
var childChkBoxCount = childChkBoxes.length;
//alert(childChkBoxCount);
for (var i = 0; i < childChkBoxCount; i++) {
childChkBoxes[i].checked = check;
}
}
function CheckUncheckParents(srcChild, check) 
{
var parentDiv = GetParentByTagName("div", srcChild);
var parentNodeTable = parentDiv.previousSibling;

if (parentNodeTable) {
var checkUncheckSwitch;

if (check) //checkbox checked
{
    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
    if (isAllSiblingsChecked)
        checkUncheckSwitch = true;
    else
        return; //do not need to check parent if any(one or more) child not checked
}
else //checkbox unchecked
{
    checkUncheckSwitch = false;
}

var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
if (inpElemsInParentTable.length > 0) {
    var parentNodeChkBox = inpElemsInParentTable[0];
    //parentNodeChkBox.checked = checkUncheckSwitch;
    //do the same recursively
    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
}
}
}
function AreAllSiblingsChecked(chkBox) 
{
var parentDiv = GetParentByTagName("div", chkBox);
var childCount = parentDiv.childNodes.length;

for (var i = 0; i < childCount; i++) {
if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
{
    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
        //if any of sibling nodes are not checked, return false
        if (!prevChkBox.checked) {
            return false;
        }
    }
}
}
return true;
}
//utility function to get the container of an element by tagname
function GetParentByTagName(parentTagName, childElementObj) 
{
var parent = childElementObj.parentNode;
while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
parent = parent.parentNode;
}
return parent;
}
function roundNumber(num, dec)
{
	var result = Math.round(num*Math.pow(10,dec))/Math.pow(10,dec);
	return result;
}
function ValFailed(ress)
{ 
    alert(ress.get_message()); 
}
//============================= DropdownList Box Binding ============================
function ValDropDownSuccess(ress,DestCtrl)
{ 
    var DestCtrl=document.getElementById(DestCtrl);
    var iLen=DestCtrl.options.length;
    for(i=iLen-1;i>=0;i--)
    {
        DestCtrl.remove(i);
        /*DestCtrl.options.remove(i);*/
    }
    //alert(ress);
    var Opt;
    for(i=0;i<=ress.length-1;i++)
	{
	    var iCount;
	    if(i%2)
	    {
	        Opt.value=ress[i];//Number is Odd
	        iCount=1;
	        DestCtrl.options.add(Opt);
	    }
	    else
	    {
	        Opt=document.createElement("OPTION");//Number is Even
	        Opt.text=ress[i];
	        iCount=0;	        
	    }
    }
}
function callDropDownData(PrmSourceCtrl,PrmDestCtrl) 
{
    document.getElementById(PrmDestCtrl).value = document.getElementById(PrmSourceCtrl).value;
    return true;
    //alert(document.getElementById(PrmSourceCtrl).value); 
}
//=========================  List Box =====================
function FnMoveItems(lstbxFrom,lstbxTo)
{
 var varFromBox = document.all(lstbxFrom);
 var varToBox = document.all(lstbxTo); 

 if ((varFromBox != null) && (varToBox != null)) 
 { 
  if(varFromBox.length < 1) 
  {
   alert('There are no items in the source ListBox');
   return false;
  }
  if(varFromBox.options.selectedIndex == -1) // when no Item is selected the index will be -1

  {
   alert('Please select an Item to move');
   return false;
  }
  while ( varFromBox.options.selectedIndex >= 0 ) 
  { 
   var newOption = new Option(); // Create a new instance of ListItem 

   newOption.text = varFromBox.options[varFromBox.options.selectedIndex].text; 
   newOption.value = varFromBox.options[varFromBox.options.selectedIndex].value; 
   varToBox.options[varToBox.length] = newOption; //Append the item in Target Listbox

   varFromBox.remove(varFromBox.options.selectedIndex); //Remove the item from Source Listbox 

  } 
 }
 return false; 
}

