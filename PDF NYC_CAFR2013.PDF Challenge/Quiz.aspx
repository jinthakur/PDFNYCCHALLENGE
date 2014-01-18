<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="Quiz" %>

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
          <li> <a href="Procedure.aspx">Procedure for Analysis</a>  </li>
          <li> <a href="HowItworks.aspx">How It works</a> </li>
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
      <h1>Quiz for a PDF </h1>
    
     <asp:ScriptManager runat="server" id="ScriptManager2">
</asp:ScriptManager>
<asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="Timer1_Tick">
        <asp:ListItem Selected="True">31</asp:ListItem><asp:ListItem>32</asp:ListItem><asp:ListItem>33</asp:ListItem></asp:DropDownList>
        
<asp:UpdatePanel runat="server" id="UpdatePanel1">
<ContentTemplate><div class="box-cnt">
<asp:TextBox ID="TextBox1" runat="server" Width="1000" Height="100" TextMode="MultiLine" >
    </asp:TextBox>
    <div>
    <asp:Label runat="server" Text="Page No." id="Label2"/> 
        </div>
<asp:Timer runat="server" id="Timer1" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
<asp:Label runat="server" Text="" id="Label1"/>
<p> Which PDF is this line from ? Write your answer. </p>

</div><asp:TextBox ID="TextBox2" runat="server">
    </asp:TextBox>
 
            </ContentTemplate>
    

    </asp:UpdatePanel>
    <asp:Button ID="Button1" runat="server" Text="Submit answer" onclick="Button1_Click" />
                  </br>
    <asp:Button ID="Button2" runat="server" Text="Save" onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Ask your Friends/ Share" onclick="Button3_Click" />
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
            
                       
                   
                    
             