<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Home</title>
    <style type="text/css">
        table {
            border-collapse: collapse;
            width: 90%;
        }

        th {
            border: 1px solid black;
            font-weight: normal;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h6>The Application is a Food Delivery System and consists of 3 pages. <br />  
The Default Page has 2 options : To login as a Member, or to login as a Staff</h6>
    <br />
    <br />
    <br />
    <div style="text-align: center;">
        <asp:Button ID="btnMemberLogin" runat="server" Text="Member Login" OnClick="btnMemberLogin_Click" />
        <asp:Button ID="btnStaffLogin" runat="server" Text="Staff Login" OnClick="btnStaffLogin_Click" />
    </div>
    <br />
    <br />
    <br />
    <hr />
    <br />
    <h6>Once you login, your credentials are stored in the cookie, unless you Log Out or the cookie expires (in this case 10 minutes) you can access any part of that particular page. 
So, if you login as a Member, then you can access all the Member related pages and services. 
And, if you login as a Staff, you can access the pages related to Staff.
The session state is also maintained across the member pages, which then in turn fetches the username of the member to display it at the eater home.</h6>
    <br />
    <p>
        Everything has been integrated into one application and you cannot access different pages without logging in, thus we are providing only ONE TryIt Page for everything. 

        Local component layer (individual work). This layer consists of the following types of components: <br />
        a. Global.asax file - Global file with the controls for session_start, session_end, application_start <br />
        b. DLL class library modules - Implemented the code to create captcha, hash the string and encrypt and decrypt the string in assignment6dll <br />
        c. Cookie for storing user profile, Session state and/or other temporary states for sharing among the - Implemented in Staff Login and Member Login(Eater and Delivery partner) <br />
        d. User control - Implemented in all the login pages, all of them have a captcha <br />
        e. XML file manipulation - 2 XML files created and accessed for the username and password for staff(StaffUsers.xml) and members(EaterUsers.xml) <br />

    </p>
    <br />
    <h6> The services implemented used here have been implemented in assignment 3 and thus the code is not provided here. For the code, please refer to our assignment 3 submissions.</h6>
    <img src="ServeImage.aspx?image=flow.png" alt="Image" />
    <div>
        
        <br />
        <br />
        
        <asp:Label ID="lblLastaccessed" runat="server"></asp:Label>
    </div>

    <br />
    <br />
    <br />
    <br />
    <h1>Service Directory</h1>
    <div>
        <table style="margin-left:auto; margin-right: auto; margin-top: 30px;">
        <tbody>
            <tr style="background-color:rgb(164, 195, 253);">
                <th width="100%" style="border: 1px solid black; padding: 8px;"><b>Service Directory</b>: The team has completed the following services.</th>
            </tr>
            <tr style="background-color:rgb(164, 195, 253);">
                <th width="100%" style="border: 1px solid black; padding: 8px;"><b>The application is deployed at</b>: <a href="http://webstrar43.fulton.asu.edu/page8/Default">http://webstrar43.fulton.asu.edu/page8/Default</a></th>
            </tr>
            <tr style="background-color: rgb(164, 195, 253);">
                <th width="100%" style="border: 1px solid black; padding: 8px;">This project is developed by: Himanshu Sharma, Sanidhya Chauhan, and Simran Bathla</th>
            </tr>
            <tr style="background-color: rgb(164, 195, 253);">
                <th width="100%" style="border: 1px solid black; padding: 8px;"><b>Individual contributions</b>: Himanshu Sharma - 33.33%, Sanidhya Chauhan - 33.33%, and Simran Bathla - 33.33%</th>
            </tr>
        </tbody>
    </table>
    <table style="margin-left:auto; margin-right: auto;">
        <tbody>
            <tr style="background-color: rgb(164, 195, 253);">
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Provider Name</b></th>
                <th width="20%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Component Type</b></th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Operation Name</b></th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Input Parameter Types/Return Types</b></th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Try It</b></th>
                <th width="20%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><b>Function Description</b></th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Event Handler</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Start_Application</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    object sender, EventArgs e
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">This method initializes routing, bundles, and sets a global session counter at the start of the application</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">DLL Function</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Encrypt</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Takes string and encrypt it using AES 128 bit encryption</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Cookie</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sign In</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/MemberLogin">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">This stores login information in browser Cookie</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">User Control</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Captcha Generator</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    int
                    <br />
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Creates a random n digit string</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">XML Manipulation</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sign Up</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string, string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/EaterHome">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Creates a user and store information in XML file</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Event Handler</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Start_Session</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    object sender, EventArgs e
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Increment the session counter</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">DLL Function</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Decrypt</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Takes a string and decrypt it</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Cookie</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Log out</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Fetch Cookie and remove user information from it</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">User Control</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Captcha Image Generate</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return type:
                    <br />
                    string, string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">It takes a random string and generates captcha image</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">XML Manipulation</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Add Staff User</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string, string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/AddCredentials">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Creates staff user and store in xml file</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Event Handler</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">End_Session</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    object sender, EventArgs e
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Prints current active sessions count</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">DLL Function</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Hash</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Takes a string and Hash it using SHA256</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Cookie</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Session State</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Fetches user information from active session</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">User Control</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Add Noise</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Default">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">It takes a Base64 encoded string and add noise to it for captcha generation</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">XML Manipulation</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Login Validation</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string, string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/MemberLogin">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Takes username and password and validated from XML file</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Sanidhya Chauhan</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">RESTfull Service</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Get Restaurant</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    string
                    <br />
                    Return Type:
                    <br />
                    string[]
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/SearchRestaurant">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Used the Yelp API with keyword restaurant to get the restaurants close to the user, maintained a data file to store the restaurant_ids and then mapped those ids to different menu items to create the menus of the restaurants which were then stored in a separate file</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Simran Bathla</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">WSDL Service</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Payment Service</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters:
                    <br />
                    int
                    <br />
                    Return Type:
                    <br />
                    string
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/PayNow">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Utilized Card Validator Rapid API, to check if the card number is valid or not. Applied checks on the expiry date, making sure that if the date is not valid, so is not the card. Made it as a WSDL service</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">WSDL Service</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Process Order</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Operation Name: AddToCart
                    <br />
                    Input Parameter: itemName (string), price (double), quantity (int) <br />
                    Return Type: void <br />

                    Operation Name: ViewCart <br />
                    Input Parameter: None <br />
                    Return Type: List<CartItem> object <br />

                    Operation Name: GetTotalAmount <br />
                    Input Parameter: None <br />
                    Return Type: totalAmount (double) <br />

                    Operation Name: PlaceOrder <br />
                    Input Parameter: emailAddress (string) <br />
                    Return Type: void <br />
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/OrderNow">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Use txt files to store data and share among different methods. Used 3rd party Google smtp server to send out actual emails. Wrote my own modular code and used local components to implement the service</th>
            </tr>
            <tr>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Himanshu Sharma</th>
                <th width="10%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">RESTfull Service</th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Delivery Service</th>
                <th width="30%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">
                    Input Parameters: orderId (string)
                    <br />
                    Output: Delivery Details (string)
                    <br />
                    Access URL: http://webstrar43.fulton.asu.edu/page3/api/delivery/{orderId}
                </th>
                <th width="10%" style="border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;"><a href="http://webstrar43.fulton.asu.edu/page8/Deliver">Try It</a></th>
                <th width="30%" style="word-wrap: break-word; border: 1px solid black; padding: 8px; text-align: left; background-color: #f2f2f2;">Used txt files to store and fetch user, restaurant, delivery partner, and order details. Used 3rd party distance matrix API to get distance and time between two places. Wrote my own modular code and used local components to implement the service. API used: https://api.distancematrix.ai/maps/api/distancematrix/json?origins=1424 S Jentilly Ln Apt 209&destinations=1265 E University Drive&key=api_key</th>
            </tr>

        </tbody>
    </table>
    </div>

</asp:Content>
