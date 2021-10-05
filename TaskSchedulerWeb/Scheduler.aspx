<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scheduler.aspx.cs" Inherits="TaskSchedulerWeb.Scheduler" %><asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery.sumoselect/3.1.6/sumoselect.min.css">
<!-- Latest compiled and minified JavaScript -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.sumoselect/3.1.6/jquery.sumoselect.min.js"></script>
<%--For Jquery datatable--%>
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="Content/Scheduler.css" rel="stylesheet" />
    <br />

<div class="h-100 h-custom gradient-custom-2" >
   <div class="container py-5 h-100">
         <div class="col-12">
                <div class="col-lg-4 col-xs-4 leftdiv">
                    <div class="p-5">
                        <div class="row">
                            
                                <label class="form-label">Task Name:</label>
                                <asp:TextBox ID="txtTaskName" runat="server" class="form-control form-control-lg"></asp:TextBox>                                 
                            
                        </div>   
                        <div class="row">
                      
                                <label class="form-label">Program Name:</label>
                                <asp:TextBox ID="txtProgramName" runat="server" class="form-control form-control-lg"></asp:TextBox>                                 
                         
                        </div>                                       
                        <div class="row">
                           
                                <label class="form-label">Add Argument(optional):</label>
                                <asp:TextBox ID="addArgmntTxtBox" class="form-control" runat="server"></asp:TextBox>                                 
                            
                        </div>                    
                        <div class="row">
                          
                                <label class="form-label">Start In(optional):</label>
                                <asp:TextBox ID="startInTxtBox" class="form-control" runat="server"></asp:TextBox>                                 
                         
                        </div>                                        
                        <div class="row">
                           
                                <label class="form-label">Connect To Server :</label>
                                   <asp:CheckBox ID="cnctToSrvrChkBox" runat="server" class="chkbox" TextAlign="Left" />                                 
                          
                        </div>
                        <div class="row">
                            <div class="text-center"  >
                                   <asp:Button ID="btnSave"  class="btn btn-primary" runat="server" Text="Create Task" OnClick="btnSave_Click" OnClientClick="return validateForm();" />                               
                                   <asp:Label ID="msgLabel" runat="server"></asp:Label>
                            </div>
                        </div> 
                    </div>            
                </div>
                <div class="col-lg-8 col-xs-4  rightdiv">
                    <div class="p-5" id="remotePanel">
                        <div class="row">
                                            <label class="form-label">Server Name:</label>
                                            <asp:TextBox ID="srvrNameTxtBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                                            <label class="form-label">User:</label>
                                            <asp:TextBox ID="userTxtBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                                            <label class="form-label">Domain:</label>
                                            <asp:TextBox ID="dmnTxtBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                                            <label class="form-label">Password:</label>
                                            <asp:TextBox ID="pwdTxtBox" class="form-control" runat="server"></asp:TextBox>
                      
                        </div>
                         
                    </div>
                </div>
</div>
        </div>  

</div>
   <div class="container" style="padding-top:5%">
   <div id="onceDiv" class="col-md-12" >
                   <hr />
       <div class="col-md-3 col-lg-3">
     
         </div>
       <div class="col-md-3 col-lg-3">
           <asp:Label ID="startLabel" runat="server" Text="Start :" class="once"></asp:Label>
           <asp:TextBox ID="startDateTxtBox" type="date" runat="server" class="form-control"></asp:TextBox>
         </div>
       <div class="col-md-3 col-lg-3">
            <asp:Label ID="endLabel" runat="server" Text="End :" class="once"></asp:Label>
            <asp:TextBox ID="endDateTxtBox" type="date" runat="server" class="form-control"></asp:TextBox>
       </div>
       <div class="col-md-3 col-lg-3">
            <asp:Label ID="timeLabel" runat="server" Text="Time :" class="once"></asp:Label>
            <asp:TextBox ID="timeTextBox" type="time" runat="server" class="form-control"></asp:TextBox>
       </div>
   </div>
   <div id="leftbox" class="col-xs-3 col-md-3 col-sm-3 col-lg-3" >
            <asp:RadioButton ID="oneTimeRadio" runat="server" GroupName="task" Text="One Time" class="space" Checked="True"/><br />
            <asp:RadioButton ID="dailyRadio" runat="server" GroupName="task" name="dailyRadio" Text="Daily" class="space" /><br />
            <asp:RadioButton ID="weeklyRadio" runat="server" GroupName="task" Text="Weekly" class="space"  /><br />
            <asp:RadioButton ID="monthlyRadio" runat="server" GroupName="task" Text="Monthly" class="space" />
   </div>         
   <div id="rightbox" class="col-sm-6 col-xs-6 col-lg-6">
         <asp:Panel ID="dailyPanel" class="dailyPanel" runat="server">
       <div id="daily" class="col-12"><label>Every</label>
           <asp:TextBox ID="numericUpDownDaily" runat="server" TextMode="Number" Width="60px" ></asp:TextBox>
           <label>days</label>
       </div>
          </asp:Panel>
         <asp:Panel ID="weeklyPanel" runat="server">
            <div id="weekly" class="col-12">          
           <label class="col-lg-2" style="text-align:left">Days</label>
               <div >
           <asp:ListBox ID="weeklyLstBox" CssClass="col-xs-6 col-sm-6 col-lg-12" runat="server" SelectionMode="Multiple">
               <asp:listitem text="Sunday" value="1"></asp:listitem>
               <asp:listitem text="Monday" value="2"></asp:listitem>
               <asp:listitem text="Tuesday" value="4"></asp:listitem>
               <asp:listitem text="Wednesday" value="8"></asp:listitem>
               <asp:listitem text="Thursday" value="16"></asp:listitem>
               <asp:listitem text="Friday" value="32"></asp:listitem>
               <asp:listitem text="Saturday" value="64"></asp:listitem>
           </asp:ListBox></div>
          
       </div>
          </asp:Panel>
         <asp:Panel ID="monthlyPanel" runat="server">
       <div id="monthly" class="col-12">
           <div class="col-xs-12">
              <label class="col-lg-2" style="text-align:center">Month</label>
           <asp:ListBox ID="monthlyLstBox" CssClass="col-xs-6 col-sm-6 col-lg-12" runat="server" SelectionMode="Multiple">
               <asp:ListItem Value="1">January</asp:ListItem>
               <asp:ListItem Value="2">February</asp:ListItem>
               <asp:ListItem Value="4">March</asp:ListItem>
               <asp:ListItem Value="8">April</asp:ListItem>
               <asp:ListItem Value="16">May</asp:ListItem>
               <asp:ListItem Value="32">June</asp:ListItem>
               <asp:ListItem Value="64">July</asp:ListItem>
               <asp:ListItem Value="128">August</asp:ListItem>
               <asp:ListItem Value="256">September</asp:ListItem>
               <asp:ListItem Value="512">October</asp:ListItem>
               <asp:ListItem Value="1024">November</asp:ListItem>
               <asp:ListItem Value="2048">December</asp:ListItem>
           </asp:ListBox>
           </div>
           <div class="col-xs-12">
               <asp:RadioButton ID="monthlyDaysRadio" name="monthlyDaysRadio" value="show" class="space col-lg-2 "  runat="server" Text="Days" GroupName="monthly"  Checked="True" />
              <div id="onLstBox"> <asp:ListBox ID="monthlyDaysLstBox" CssClass="col-xs-6 col-sm-6 col-lg-12" runat="server" SelectionMode="Multiple">
               <asp:ListItem Value="1">1</asp:ListItem>
               <asp:ListItem Value="2">2</asp:ListItem>
               <asp:ListItem Value="4">3</asp:ListItem>
               <asp:ListItem Value="8">4</asp:ListItem>
               <asp:ListItem Value="16">5</asp:ListItem>
               <asp:ListItem Value="32">6</asp:ListItem>
               <asp:ListItem Value="64">7</asp:ListItem>
               <asp:ListItem Value="128">8</asp:ListItem>
               <asp:ListItem Value="256">9</asp:ListItem>
               <asp:ListItem Value="512">10</asp:ListItem>
               <asp:ListItem Value="1024">11</asp:ListItem>
               <asp:ListItem Value="2048">12</asp:ListItem>
               <asp:ListItem Value="4096">13</asp:ListItem>
               <asp:ListItem Value="8192">14</asp:ListItem>
               <asp:ListItem Value="16384">15</asp:ListItem>
               <asp:ListItem Value="32768">16</asp:ListItem>
               <asp:ListItem Value="65536">17</asp:ListItem>
               <asp:ListItem Value="131072">18</asp:ListItem>
               <asp:ListItem Value="262144">19</asp:ListItem>
               <asp:ListItem Value="524288">20</asp:ListItem>
               <asp:ListItem Value="1048576">11</asp:ListItem>
               <asp:ListItem Value="2097152">22</asp:ListItem>
               <asp:ListItem Value="4194304">23</asp:ListItem>
               <asp:ListItem Value="8388608">24</asp:ListItem>
               <asp:ListItem Value="16777216">25</asp:ListItem>
               <asp:ListItem Value="33554432">26</asp:ListItem>
               <asp:ListItem Value="67108864">27</asp:ListItem>
               <asp:ListItem Value="134217728">28</asp:ListItem>
               <asp:ListItem Value="268435456">29</asp:ListItem>
               <asp:ListItem Value="536870912">30</asp:ListItem>
               <asp:ListItem Value="1073741824">31</asp:ListItem>
               <asp:ListItem Value="Last Day">Last Day</asp:ListItem>
           </asp:ListBox></div>
           </div>
           <div class="col-xs-12">
               <asp:RadioButton ID="monthlyOnRadio" class="space col-lg-2" runat="server"  Text="On" GroupName="monthly"  />
        <div id="daysLstBox">    
            <asp:ListBox ID="onWeekNumberLstBox" CssClass="col-xs-6 col-sm-6 col-lg-12" runat="server" SelectionMode="Multiple">
               <asp:listitem text="First" value="1"></asp:listitem>
               <asp:listitem text="Second" value="2"></asp:listitem>
               <asp:listitem text="Third" value="4"></asp:listitem>
               <asp:listitem text="Fourth" value="8"></asp:listitem>
               <asp:listitem text="Last" value="Last"></asp:listitem>
           </asp:ListBox>
               <asp:ListBox ID="OnWeekDaysLstBox" CssClass="col-xs-6 col-lg-12" runat="server" SelectionMode="Multiple">
               <asp:listitem text="Sunday" value="1"></asp:listitem>
               <asp:listitem text="Monday" value="2"></asp:listitem>
               <asp:listitem text="Tuesday" value="4"></asp:listitem>
               <asp:listitem text="Wednesday" value="8"></asp:listitem>
               <asp:listitem text="Thursday" value="16"></asp:listitem>
               <asp:listitem text="Friday" value="32"></asp:listitem>
               <asp:listitem text="Saturday" value="64"></asp:listitem>
           </asp:ListBox></div>
           </div>          
               </div>
      </asp:Panel>         
    </div>
        </div>
   <div id="listTable" >
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-bordered table-striped " OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand"
        HeaderStyle-BackColor="#b3cbff">
         <Columns>    
                 <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="30" >    
<ItemStyle Width="30px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Width="150" >    
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Triggers" HeaderText="Triggers" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
             <asp:BoundField DataField="NextRunTime" HeaderText="NextRunTime" ItemStyle-Width="30" >    
<ItemStyle Width="30px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="LastRunTime" HeaderText="LastRunTime" ItemStyle-Width="150" >    
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="LastTaskResult" HeaderText="LastTaskResult" ItemStyle-Width="150" >  
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
             <asp:BoundField DataField="Author" HeaderText="Author" ItemStyle-Width="30" >    
<ItemStyle Width="30px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                 </asp:BoundField>
             <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
            <asp:Button ID="Button" Text="Delete" runat="server" CommandName="Delete" class="btn-danger" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="return confirm('Are you sure you want to delete this event?');" />
        </ItemTemplate>
    </asp:TemplateField>
         </Columns>
    </asp:GridView>
        
</div>
 <script type="text/javascript">
            //dropdown part
            $(document).ready(function () {
                    $(<%=weeklyLstBox.ClientID%>).SumoSelect();                
                             
            });
            $(document).ready(function () {
                $(<%=monthlyLstBox.ClientID%>).SumoSelect();  
                $(<%=monthlyDaysLstBox.ClientID%>).SumoSelect();
                   
            });
            $(document).ready(function () {
                $(<%=onWeekNumberLstBox.ClientID%>).SumoSelect();                               
                $(<%=OnWeekDaysLstBox.ClientID%>).SumoSelect();
                                                     
            });
            //other part
            $(document).ready(function () {
                $('#remotePanel').hide();
                $('#MainContent_dailyPanel').hide();
                $('#MainContent_weeklyPanel').hide();
                $('#MainContent_monthlyPanel').hide();

                $('#MainContent_cnctToSrvrChkBox').click(function () {
                    if ($(this).is(":checked")) {
                        $('#remotePanel').show();
                    } else {                       
                        $('#remotePanel').hide();
                    }
                   
                });
                $('#MainContent_oneTimeRadio').click(function () {
                    $('#MainContent_dailyPanel').hide();
                    $('#MainContent_weeklyPanel').hide();
                    $('#MainContent_monthlyPanel').hide();
                })
                $('#MainContent_dailyRadio').click(function () {
                    $('#MainContent_dailyPanel').show();
                    $('#MainContent_weeklyPanel').hide();
                    $('#MainContent_monthlyPanel').hide();
                })
                $('#MainContent_weeklyRadio').click(function () {
                    $('#MainContent_dailyPanel').hide();
                    $('#MainContent_weeklyPanel').show();
                    $('#MainContent_monthlyPanel').hide();
                })
                $('#MainContent_monthlyRadio').click(function () {
                    $('#MainContent_dailyPanel').hide();
                    $('#MainContent_weeklyPanel').hide();
                    $('#MainContent_monthlyPanel').show();
                    $('#daysLstBox').hide();
                });
                $('#MainContent_monthlyOnRadio').click(function () {
                    $('#daysLstBox').show();
                    $('#onLstBox').hide();
                });
                $('#MainContent_monthlyDaysRadio').click(function () {
                    $('#daysLstBox').hide();
                    $('#onLstBox').show();
                });

                
            });
     function validateForm() {                   
                            if ($('#MainContent_cnctToSrvrChkBox').is(":checked")) {
                            if ($("#MainContent_txtTaskName").val() == "" || $("#MainContent_txtTaskName").val() == undefined) {
                 alert("Enter Task Name");
                 return false;
             }
                            if ($("#MainContent_txtProgramName").val() == "" || $("#MainContent_txtProgramName").val() == undefined) {
                 alert("Enter Program Name");
                 return false;
             }
                            if ($("#MainContent_startDateTxtBox").val() == "" || $("#MainContent_startDateTxtBox").val() == undefined) {
                 alert("Enter Start Date");
                 return false;
             }
                            if ($("#MainContent_endDateTxtBox").val() == "" || $("#MainContent_endDateTxtBox").val() == undefined) {
                 alert("Enter End Date");
                 return false;
             }
                            if ($("#MainContent_timeTextBox").val() == "" || $("#MainContent_timeTextBox").val() == undefined) {
                 alert("Enter Time");
                 return false;
             }
                            if ($("#MainContent_srvrNameTxtBox").val() == "" || $("#MainContent_srvrNameTxtBox").val() == undefined) {
                                alert("Enter Server Name");
                                return false;
                            }
                            if ($("#MainContent_userTxtBox").val() == "" || $("#MainContent_userTxtBox").val() == undefined) {
                                alert("Enter User Name");
                                return false;
                            }
                            if ($("#MainContent_dmnTxtBox").val() == "" || $("#MainContent_dmnTxtBox").val() == undefined) {
                                alert("Enter Domain Name");
                                return false;
                            }
                            if ($("#MainContent_pwdTxtBox").val() == "" || $("#MainContent_pwdTxtBox").val() == undefined) {
                                alert("Enter Password");
                                return false;
                            }

                        } else {
                            if ($("#MainContent_txtTaskName").val() == "" || $("#MainContent_txtTaskName").val() == undefined) {
                                alert("Enter Task Name");
                                return false;
                            }
                            if ($("#MainContent_txtProgramName").val() == "" || $("#MainContent_txtProgramName").val() == undefined) {
                                alert("Enter Program Name");
                                return false;
                            }
                            if ($("#MainContent_startDateTxtBox").val() == "" || $("#MainContent_startDateTxtBox").val() == undefined) {
                                alert("Enter Start Date");
                                return false;
                            }
                            if ($("#MainContent_endDateTxtBox").val() == "" || $("#MainContent_endDateTxtBox").val() == undefined) {
                                alert("Enter End Date");
                                return false;
                            }
                            if ($("#MainContent_timeTextBox").val() == "" || $("#MainContent_timeTextBox").val() == undefined) {
                                alert("Enter Time");
                                return false;
                            }

                        }                                            
     };
         

     //$('#userTable').DataTable();
     $('#MainContent_GridView1').DataTable();
   
 </script>

  
</asp:Content>
