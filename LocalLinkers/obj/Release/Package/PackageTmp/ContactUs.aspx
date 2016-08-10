<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="LocalLinkers.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!--+++++++++++++++++++++++++++++++++++++++++ Start Contact Div ++++++++++++++++++++++++++++++++++++++++++-->


<div class="contactUs_form">


<div class="wrapper">
    <div class="parallax">
           <div class="company-description">
               <h4>Local Linkers</h4>
               <p>D-185, Level III, Phase 8b, Industrial Area, Mohali, Punjab </p>
           </div>
           <!-- <div id="contactUsMap" class="big-map"></div>-->
           
           <div class="maplocal">
           <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13721.063772181833!2d76.6875466883917!3d30.710923204720075!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x390fee5821410c4d%3A0x95be4ab5acbadb43!2sIndustrial+Area+Mohali%2C+Sahibzada+Ajit+Singh+Nagar%2C+Punjab!5e0!3m2!1sen!2sin!4v1460034523242" width="100%" height="600" frameborder="0" style="border:0" allowfullscreen></iframe>
           
           
           </div>
           
           
    </div>

    <div class="section">
           <div class="container">
               <h2 class="section-title">Contact Us for your Queries</h2>
               <div class="row">
                   <div class="col-md-6">
                       <p>
                           If you have any questions, concerns or feedback for us, kindly drop us a line and we shall get back to you.<br><br>
                        </p>
                        <%--<form role="form" id="contact-form" method="post">--%>
    						<div class="form-group">
    				    		<label for="name">Your name</label>
    				    		<input type="text" runat="server" name="name" class="form-control" id="name" placeholder="First Name and Last Name"/>
    				  		</div>
    				  		<div class="form-group">
    				    		<label for="email">Email address</label>
    				    		<input type="email" runat="server" name="email" class="form-control" id="email" placeholder="Your personal email address"/>
    				  		</div>
    				  		<div class="form-group">
    				    		<label for="phone">Phone</label>
    				    		<input type="text" runat="server" name="phone" class="form-control" id="phone" placeholder="Phone number"/>
    				  		</div>
    				  		<div class="form-group">
    				    		<label for="message">Your message</label>
    				    		<textarea name="message" runat="server" class="form-control" id="message" rows="6"></textarea>
    				  		</div>
    				  		<div class="submit">
    				  			<asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info btn-fill" Text="Contact Us" OnClick="btnSubmit_Click" />
    				  		</div>
    					<%--</form>--%>
                   </div>
                   <div class="col-md-4 col-md-offset-2">
                        <div class="contact-info">
                            <h5><i class="fa fa-map-marker text-muted"></i> Address</h5>
                            <p class="text-muted"> D-185, Level III <br/>
Phase 8b, Industrial Area <br/>
Mohali, Punjab <br/>
India – 160071 
                            </p><br>
                            <h5><i class="fa fa-phone text-muted"></i> Live Support</h5>
                            <p class="text-muted">  +91 9219999000 <br>
                                Mon - Sat, 9:00-19:00
                            </p><br>
                            <h5><i class="fa fa-building text-muted"></i> Business Info</h5>
                            <p class="text-muted"> Creative Thinkosys Web Services Pvt. Ltd.<br>
                            </p>
                        </div>
                   </div>
               </div>
           </div>
    </div><!-- section -->
    <div class="space-50"></div>
    
        
    
</div>









</div>


<!--+++++++++++++++++++++++++++++++++++++++++ End Contact Div ++++++++++++++++++++++++++++++++++++++++++-->

</asp:Content>

