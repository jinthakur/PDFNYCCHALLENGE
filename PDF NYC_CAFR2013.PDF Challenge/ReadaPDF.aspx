<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadaPDF.aspx.cs" Inherits="ReadaPDF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head runat="server">
<title>I Read Your PDF</title>
<meta charset="utf-8">
<link rel="shortcut icon" type="image/x-icon" href="css/images/favicon.ico">
<link rel="stylesheet" href="css/style.css" type="text/css" media="all">
<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="all">
<script src="js/jquery-1.7.2.min.js"></script>
<!--[if lt IE 9]><script src="js/modernizr.custom.js"></script><![endif]-->
<script src="js/jquery.flexslider-min.js"></script>
<script src="js/functions.js"></script>
</head>
<body>
<!-- wrapper -->
<div id="wrapper">
  <!-- header -->
  <header class="header">
    <div class="shell">
      <h1 id="logo"><a href="#">I Read Your PDF</a></h1>
      
      <!-- navigation -->
     <nav id="navigation">
        <ul>
        <li class="active"> <a href="index.html">Home</a>  </li>
          
          <li> <a href="Login.aspx">Login</a>  </li>
          <li> <a href="#">About</a>  </li>
         <li><a href="ReadaPDFTable.aspx">ReadaPDFTable.aspx</a> </li>
          <li> <a href="ReadaPDF.aspx">Read a PDF</a>  </li>
      
        
        </ul>
        <div class="cl">&nbsp;</div>
      </nav>
      <!-- end of navigation -->
    </div>
  </header>
  <!-- end of header -->
  <!-- slider-holder -->
   <span class="l"></span> <span class="r"></span> <span class="t"></span> <span class="b"></span> &nbsp;<!-- slider -->
   <div class="shell">
       <form id="form2" runat="server">
    <div class="box-cnt">
      <h1>Reading a PDF </h1>
    
     <asp:ScriptManager runat="server" id="ScriptManager2">
</asp:ScriptManager>
<asp:Button ID="Button1" runat="server" Text="Edit" onclick="Button1_Click" />
                 <asp:Button ID="Button4" runat="server" Text="Save  As it is " onclick="Button4_Click" />
    <asp:Button ID="Button2" runat="server" Text="Save  As CSV " onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Send For Share" onclick="Button3_Click" />
<asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="Timer1_Tick">
        <asp:ListItem Selected="True">31</asp:ListItem><asp:ListItem>32</asp:ListItem><asp:ListItem>33</asp:ListItem></asp:DropDownList>
        <a href="PDF/9780306822315-text.pdf">PDF/NYC_CAFR2013.pdf</a>
<asp:UpdatePanel runat="server" id="UpdatePanel1">
<ContentTemplate><div class="box-cnt">
<asp:TextBox ID="TextBox1" runat="server" Width="1000" Height="1000" TextMode="MultiLine" >
    </asp:TextBox>
    <div>
    <asp:Label runat="server" Text="Page No." id="Label2"/> 
        </div>
<asp:Timer runat="server" id="Timer1" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
<asp:Label runat="server" Text="Page not refreshed yet." id="Label1"/>
<p> Your Rating /Review </p>

</div>
 
    <AjaxControlToolkit:SliderExtender  
                ID="SliderExtender1"  
                BoundControlID="slider1_display"  
                Decimals="0"  
                Minimum="0"  
                Maximum="100"  
                runat="server"  
                TargetControlID="slider1"  
                EnableHandleAnimation="true"  
                TooltipText="{0}">  
            </AjaxControlToolkit:SliderExtender>  
              <br>  
              </br>
            <asp:TextBox ID="slider1" runat="server"></asp:TextBox>  
            <asp:Label ID="slider1_display" runat="server"></asp:Label>  
              <br>  
              </br>
                
            </ContentTemplate>

    </asp:UpdatePanel>
    
      <!-- AddThis Button BEGIN -->
                                <div class="addthis_toolbox addthis_default_style addthis_32x32_style">
                                    <a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2">
                                    </a><a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4">
                                    </a><a class="addthis_button_compact"></a><a class="addthis_counter addthis_bubble_style">
                                    </a>
                                </div>
                                <script type="text/javascript">                                    var addthis_config = { "data_track_clickback": true };</script>
                                <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d6c52d60ca3cc28"></script>
                                <!-- AddThis Button END -->
      </div>
    </form>
      </div>
<!-- end of footer -->
</body>
</html>
            
                       
                   
                    
             