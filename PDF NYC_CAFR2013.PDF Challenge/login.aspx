<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
  <div class="slider-holder">
    <!-- shell -->
    <div class="shell"> <span class="l"></span> <span class="r"></span> <span class="t"></span> <span class="b"></span> &nbsp;<!-- slider --><div class="slider flexslider">
       <form id="form2" runat="server">
    <div>
        <asp:Login ID="Login2" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="Large" ForeColor="#333333" onauthenticate="Login1_Authenticate" 
            Width="460px" CssClass="header">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
        </asp:Login>
        <p> Login with  Admin \admin</p>
    </div>
    </form>
      </div>
      <!-- end of slider -->
    </div>
    <!-- end of shell -->
  </div>
  <!-- end of slider-holder -->
  <!-- shell -->
  <div class="shell">
    <!-- main -->
  
    <!-- end of main -->
  </div>
  <!-- end of shell -->
  <div id="footer-push"></div>
  <!-- wrapper -->
  <!-- footer -->
  <div id="footer">
    <div class="shell">
      <!-- footer-cols -->
      <section class="footer-cols">
        <div class="col">
          <h3>MORE <strong>ABOUT US</strong></h3>
        </div>
        <div class="col">
          <h3>KEEP <strong>IN TOUCH</strong></h3>
          <p>&nbsp;</p>
          <form method="post" action="#">
            <input type="text" class="field" value="Your Email Here">
            <input type="submit" class="submit-btn" value="Submit">
          </form>
        </div>
        <div class="col contact">
          <h3>CONTACT <strong>US</strong></h3>
          <h4>+1 646 580 5887</h4>
            <a href="#">jin@askyourquestiobns.info</a></div>
        <div class="cl">&nbsp;</div>
      </section>
      <!-- end of footer-cols -->
      <p class="copy">&copy; askyourQuestions.info. </p>
      <div class="cl">&nbsp;</div>
    </div>
  </div>
</div>
<!-- end of footer -->
</body>
</html>
            
                       
                   
                    
             