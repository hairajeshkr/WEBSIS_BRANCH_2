
function ValidateMasterData()  
{
    var DdlUsrGrp = document.getElementById('ContentPlaceHolder1_DdlUsrGrp');
    
    if(isListSelected(DdlUsrGrp,'Please select user group.',DdlUsrGrp,0))
        {
            return true;
        }
        else
        {
            return false;
        }
}
function FnCheckAll(PrmGrdVw,PrmRowIndex,PrmMenuId,PrmCurntChkBox,PrmParentId,PrmChkdBox)
{ 
   /*alert(PrmGrdVw);alert(PrmRowIndex);alert(PrmMenuId); */
    var grid = document.getElementById(PrmGrdVw);
    var gridLength = grid.rows.length;
    var nParentId=0,nMenuId=0;
    for (var i = 0; i < gridLength-1; i++)
    {
        nMenuId = parseFloat(document.getElementById('ContentPlaceHolder1_GrdVwRecords_HdnMenuId_' + i).value);
        nParentId = parseFloat(document.getElementById('ContentPlaceHolder1_GrdVwRecords_HdnParentId_' + i).value);
        if(PrmMenuId==nParentId)
        {
            if(document.getElementById(PrmCurntChkBox).checked ==true)
            {
                document.getElementById('ContentPlaceHolder1_GrdVwRecords' + PrmChkdBox + "_" + i).checked = true;
            }
            else
            {
                document.getElementById('ContentPlaceHolder1_GrdVwRecords' + PrmChkdBox + "_" + i).checked = false;
            }
        }
        if(PrmParentId==nMenuId)
        {
            document.getElementById('ContentPlaceHolder1_GrdVwRecords' + PrmChkdBox + "_" + i).checked = true;
        }
    }
} 
function FnCheckParent(PrmGrdVw,PrmCurntChkBox,PrmParentId,PrmChkdBox)
{
    var grid = document.getElementById(PrmGrdVw);
    var gridLength = grid.rows.length;
    var nMenuId = 0;
    for (var i = 0; i < gridLength-1; i++)
    {
        nMenuId = parseFloat(document.getElementById('ContentPlaceHolder1_GrdVwRecords_HdnMenuId_' + i).value);
         if(PrmParentId==nMenuId)
         {
             document.getElementById('ContentPlaceHolder1_GrdVwRecords' + PrmChkdBox + "_" + i).checked = true;
         }
    }
}