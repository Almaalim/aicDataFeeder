<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="UserDepartment.aspx.cs" Inherits="Pages_UserDepartment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script language="javascript" type="text/javascript">
        //************************** Treeview Parent-Child check behaviour ****************************//  

        function OnTreeClick(evt) {
            //            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            //            if (isChkBoxClick) {
            //                var parentTable = GetParentByTagName("table", src);
            //                var nxtSibling = parentTable.nextSibling;
            //                if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
            //                {
            //                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
            //                    {
            //                        //check or uncheck children at all levels
            //                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
            //                    }
            //                }
            //                //check or uncheck parents at all levels
            //                //            CheckUncheckParents(src, src.checked);
            //            }
        }

        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
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
                        return; //do not need to check parent if any child is not checked
                }
                else //checkbox unchecked
                {
                    checkUncheckSwitch = false;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
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
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }

    </script>
    <script type="text/javascript">
        function OnCheckBoxCheckChanged(evt) {
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
                // CheckUncheckParents(src, src.checked);
            }
        }
        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }
        function CheckUncheckParents(srcChild, check) {
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
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively 
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }
        function AreAllSiblingsChecked(chkBox) {
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
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }
    </script>
    <script type="text/javascript">
        var TREEVIEW_ID = "ctl00_ContentPlaceHolder1_TreeView1n0"; //the ID of the TreeView control
        //the constants used by GetNodeIndex()
        var LINK = 0;
        var CHECKBOX = 1;

        //this function is executed whenever user clicks on the node text
        function ToggleCheckBox(senderId) {


            var nodeIndex = GetNodeIndex(senderId, LINK);
            var checkBoxId = TREEVIEW_ID + "n" + nodeIndex + "CheckBox";
            var checkBox = document.getElementById(checkBoxId);
            checkBox.checked = !checkBox.checked;

            ToggleChildCheckBoxes(checkBox);
            ToggleParentCheckBox(checkBox);
        }

        //checkbox click event handler
        function checkBox_Click(eventElement) {
            ToggleChildCheckBoxes(eventElement.target);
            ToggleParentCheckBox(eventElement.target);
        }

        //returns the index of the clicked link or the checkbox
        function GetNodeIndex(elementId, elementType) {
            var nodeIndex;
            if (elementType == LINK) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "t").length);
            }
            else if (elementType == CHECKBOX) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "n").length, elementId.indexOf("CheckBox"));
            }
            return nodeIndex;
        }

        //checks or unchecks the nested checkboxes
        function ToggleChildCheckBoxes(checkBox) {
            var postfix = "n";
            var childContainerId = TREEVIEW_ID + postfix + GetNodeIndex(checkBox.id, CHECKBOX) + "Nodes";
            var childContainer = document.getElementById(childContainerId);
            if (childContainer) {
                var childCheckBoxes = childContainer.getElementsByTagName("input");
                for (var i = 0; i < childCheckBoxes.length; i++) {
                    childCheckBoxes[i].checked = checkBox.checked;
                }
            }
        }

        //unchecks the parent checkboxes if the current one is unchecked
        function ToggleParentCheckBox(checkBox) {
            //            if(checkBox.checked == false)
            //            {
            //                var parentContainer = GetParentNodeById(checkBox, TREEVIEW_ID);
            //                if(parentContainer) 
            //                {
            //                    var parentCheckBoxId = parentContainer.id.substring(0, parentContainer.id.search("Nodes")) + "CheckBox";
            //                    if($get(parentCheckBoxId) && $get(parentCheckBoxId).type == "checkbox") 
            //                    {
            //                        $get(parentCheckBoxId).checked = false;
            //                        ToggleParentCheckBox($get(parentCheckBoxId));
            //                    }
            //                }
            //            }
        }

        //returns the ID of the parent container if the current checkbox is unchecked
        function GetParentNodeById(element, id) {
            var parent = element.parentNode;
            if (parent == null) {
                return false;
            }
            if (parent.id.search(id) == -1) {
                return GetParentNodeById(parent, id);
            }
            else {
                return parent;
            }
        }
    </script>
    <script type="text/javascript">
        var links = document.getElementsByTagName("a");
        for (var i = 0; i < links.length; i++) {
            if (links[i].className == TREEVIEW_ID + "_0") {
                links[i].href = "javascript:ToggleCheckBox(\"" + links[i].id + "\");";
            }
        }

        var checkBoxes = document.getElementsByTagName("input");
        for (var i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i].type == "checkbox") {
                $addHandler(checkBoxes[i], "click", checkBox_Click);
            }
        }
    </script>

    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="UsrLoginID" Text="Username"></asp:ListItem>
                                <%--<asp:ListItem Value="DepNameAr" Text="Department Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="DepNameEn" Text="Department Name (En)"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" CssClass="CustomValidator"
                                ControlToValidate="txtSearch" EnableClientScript="False" ValidationGroup="vgSearch"
                                Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                            </asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" ValidationGroup="vgSearch" Enabled="False" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdMainData" runat="server" AutoGenerateColumns="False" CssClass="vGrid"
                            DataKeyNames="DepID" Width="100%"
                            GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                            AllowPaging="True"
                            OnDataBound="grdMainData_DataBound" OnSelectedIndexChanged="grdMainData_SelectedIndexChanged"
                            OnRowDataBound="grdMainData_RowDataBound"
                            OnSorting="grdMainData_Sorting" OnRowCreated="grdMainData_RowCreated"
                            OnPageIndexChanging="grdMainData_PageIndexChanging" ShowFooter="True"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="UsrLoginID" HeaderText="Username" SortExpression="UsrLoginID">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="UsrFullName" HeaderText="Full Name" SortExpression="UsrFullName">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>

                <div class="GreySetion">
                    <asp:Panel ID="pnlMainTitel" runat="server" CssClass="collapsePanelTitelHeader">
                        <asp:HyperLink ID="hlkMainTitel" runat="server" Text="Department Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                        <asp:Label ID="lblMainTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" />
                        <asp:Image ID="imgMainTitel" runat="server" CssClass="collapsePanelImage" />
                    </asp:Panel>

                    <div class="collapsePanelDataBorder">
                        <cc1:CollapsiblePanelExtender ID="epnlMainData" runat="server" Enabled="True"
                            TargetControlID="pnlMainData"
                            CollapsedSize="0" Collapsed="true"
                            ExpandControlID="pnlMainTitel" CollapseControlID="pnlMainTitel" AutoCollapse="false" AutoExpand="false"
                            CollapsedText="(Show Details...)" ExpandedText="(Hide Details)" ExpandDirection="Vertical"
                            TextLabelID="lblMainTitel" ImageControlID="imgMainTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                        </cc1:CollapsiblePanelExtender>

                        <asp:Panel ID="pnlMainData" runat="server" CssClass="collapsePanelData">
                            <div class="row">
                                <div class="col8">
                                    <%--<asp:LinkButton ID="btnMainAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnMainAdd_Click"></asp:LinkButton>--%>

                                    <asp:LinkButton ID="btnMainEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="false"
                                        OnClick="btnMainEdit_Click"></asp:LinkButton>

                                    <%--<asp:LinkButton ID="btnMainDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="false"
                                        OnClick="btnMainDelete_Click"></asp:LinkButton>--%>

                                    <asp:LinkButton ID="btnMainSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="false"
                                        OnClick="btnMainSave_Click" ValidationGroup="vgSave"></asp:LinkButton>

                                    <asp:LinkButton ID="btnMainCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="false"
                                        OnClick="btnMainCancel_Click"></asp:LinkButton>
                                    <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" CssClass="CustomValidator"
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col12">
                                    <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                                    <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col12">
                                    <span class="h3">
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department"
                                            meta:resourcekey="lblDepartmentResource1"></asp:Label></span>
                                    <asp:CustomValidator ID="cvDepartment" runat="server"
                                        ValidationGroup="vgSave"
                                        OnServerValidate="tree_ServerValidate"
                                        EnableClientScript="False"
                                        ControlToValidate="txtValid"
                                        meta:resourcekey="cvDepartmentResource1"></asp:CustomValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col12">
                                    <asp:XmlDataSource ID="xmlDataSource2" runat="server" TransformFile="~/XSL/DepTransformXSLT.xsl"
                                        CacheExpirationPolicy="Sliding" XPath="MenuItems/MenuItem" EnableCaching="False" />
                                    <asp:TreeView ID="trvDept" runat="server" LineImagesFolder="~/images/TreeLineImages" DataSourceID="xmlDataSource2"
                                        ShowLines="True" ShowCheckBoxes="All" OnDataBound="trvDept_DataBound"
                                        OnTreeNodeDataBound="trvDept_TreeNodeDataBound" ForeColor="#CAD2D6"
                                        meta:resourcekey="trvDeptResource1">
                                        <DataBindings>
                                            <asp:TreeNodeBinding DataMember="MenuItem" TextField="Text" ValueField="Value"
                                                meta:resourcekey="TreeNodeBindingResource1" ImageUrlField="Check" />
                                        </DataBindings>
                                    </asp:TreeView>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>

                </div>

                <%--<div class="col1">
                        <asp:Label ID="lblSearchBy" runat="server" Text="Search By:"
                            meta:resourcekey="Label1Resource1"></asp:Label>
                    </div>
                    <div class="col2">
                        <asp:DropDownList ID="ddlFilter" runat="server"
                            meta:resourcekey="ddlFilterResource1">
                            <asp:ListItem Selected="True" meta:resourcekey="ListItemResource1">[None]</asp:ListItem>
                            <asp:ListItem Text="User Name" Value="UsrName"
                                meta:resourcekey="ListItemResource2"></asp:ListItem>
                            <asp:ListItem Text="Department Name (Ar)" Value="DepNameAr"
                                meta:resourcekey="ListItemResource3"></asp:ListItem>
                            <asp:ListItem Text="Department Name (En)" Value="DepNameEn"
                                meta:resourcekey="ListItemResource4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col2">
                        <asp:TextBox ID="txtFilter" runat="server" AutoCompleteType="Disabled"
                            meta:resourcekey="txtFilterResource1"></asp:TextBox>

                        <asp:ImageButton ID="btnFilter" runat="server" OnClick="btnFilter_Click" CssClass="LeftOverlay"
                            ImageUrl="../images/Button_Icons/button_magnify.png"
                            meta:resourcekey="btnFilterResource1" />
                    </div>--%>


                <%--<div class="row">
                    <div class="col12">
                        <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Literal1Resource1"></asp:Literal>
                    </div>
                </div>--%>

                <%--<div class="row">
                    <div class="col12">
                        <as:gridviewkeyboardpagerextender runat="server" id="gridviewextender" targetcontrolid="grdData" />
                        <asp:GridView ID="grdData" runat="server" CssClass="datatable"
                            SelectedIndex="0" AutoGenerateColumns="False"
                            AllowPaging="True" CellPadding="0" BorderWidth="0px" GridLines="None" DataKeyNames="UsrName"
                            ShowFooter="True" OnPageIndexChanging="grdData_PageIndexChanging" OnRowCreated="grdData_RowCreated"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting"
                            OnRowCommand="grdData_RowCommand" OnPreRender="grdData_PreRender"
                            OnSelectedIndexChanged="grdData_SelectedIndexChanged" meta:resourcekey="grdDataResource1">

                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First"
                                FirstPageImageUrl="~/images/first.gif" LastPageText="Last" LastPageImageUrl="~/images/last.gif"
                                NextPageText="Next" NextPageImageUrl="~/images/next.gif" PreviousPageText="Prev"
                                PreviousPageImageUrl="~/images/prev.gif" />
                            <Columns>
                                <asp:BoundField DataField="UsrName" HeaderText="User Name"
                                    SortExpression="UsrName" meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="UsrFullName" HeaderText="Full Name" SortExpression="UsrFullName"
                                    meta:resourcekey="BoundFieldResource422" />
                            </Columns>


                        </asp:GridView>
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess"
                            EnableClientScript="False" ValidationGroup="ShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="col12">
                        <asp:ValidationSummary runat="server" ID="vsSave" ValidationGroup="vgSave" EnableClientScript="False"
                            CssClass="MsgValidation" ShowSummary="False" meta:resourcekey="vsumAllResource1" />
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="col8">
                        <asp:LinkButton ID="btnModify" runat="server" CssClass="GenButton glyphicon glyphicon-edit"
                            OnClick="btnModify_Click"
                            Text="&lt;img src=&quot;../images/Button_Icons/button_edit.png&quot; /&gt; Modify"
                            meta:resourcekey="btnModifyResource1"></asp:LinkButton>

                        <asp:LinkButton ID="btnSave" runat="server" CssClass="GenButton glyphicon glyphicon-floppy-disk"
                            OnClick="btnSave_Click" ValidationGroup="Groups"
                            Text="&lt;img src=&quot;../images/Button_Icons/button_storage.png&quot; /&gt; Save"
                            meta:resourcekey="btnSaveResource1"></asp:LinkButton>

                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle"
                            OnClick="btnCancel_Click"
                            Text="&lt;img src=&quot;../images/Button_Icons/button_Cancel.png&quot; /&gt; Cancel"
                            meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                    </div>
                    <div class="col8">
                        <asp:TextBox ID="txtValid" runat="server" Text="02120" Visible="False"
                            Width="10px" meta:resourcekey="txtCustomValidatorResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None"
                            ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                            EnableClientScript="False" ControlToValidate="txtValid" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>

                    </div>
                </div>--%>

                <div class="row">
                    <div class="col12">
                        <asp:TextBox ID="txtID" runat="server" AutoCompleteType="Disabled" Enabled="False" Visible="False" Width="15px" meta:resourcekey="txtIDResource1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

