<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDistance.aspx.cs" Inherits="TeacherComputerRetrieval_NewGlobe.TestDistance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0, user-scalable=yes, maximum-scale=5.0" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript">  
        $(document).ready(function () {
            //$('#GetAcademies').on("keyup", function (e) {
            //    $("#maxStops").val("");
            //    $("#GetTotalRoutes").css('visibility', 'hidden');            
            //});

            //if (maxStops.val == "") {
            //    $("#GetTotalRoutes").css('visibility', 'hidden');
            //}

            //$('#GetAcademyDetails').on("keyup", function () {
            //    $("#inputMaxDistance").val("");              
            //});
        });
    </script>  
    <style>
        .flex-container {
            display:flex; 
            flex-direction:row;
            margin-top:100px;
                
        }
        #firstDiv,#secondDiv, #thirdDiv, #fourthDiv {
          background-color: lightgrey;
          width: 250px;
          border: 3px solid black; 
          padding: 30px;
          margin: 20px;
        }
        #firstDiv{
            margin-left:70px;
        }

        #firstDiv, #thirdDiv {
            background-color: lightgray;
        }  
        #secondDiv, #fourthDiv {         
            background-color: lightblue
        } 
       
    </style>

</head >
   <body>
    <form id="form2" runat="server" >
        <div class="flex-container">
            <div id="firstDiv">
                <label for="routesToGetDistance" style="text-transform: uppercase;"><strong>Measure distance</strong></label>
                <br /><br />
                Enter Routes: <asp:TextBox ID="GetRoutes" runat="server"  onkeydown="return /[a-e]/i.test(event.key)" AutoPostBack = "true" OnTextChanged="Result_TextChanged"></asp:TextBox> <%--OnTextChanged="GetRoutes_TextChanged"--%>
                <br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                <br /><br />
                <%--Total Routes:<asp:TextBox ID="FinalDistance" runat="server" enabled="false" AutoPostBack = "true"></asp:TextBox>--%>
                <asp:label id="GetResult" runat="server" style="color:red;"></asp:label>
                <br /><br />
                

            </div> <br /><br />


            <div id="secondDiv">
                <label for="forDiffRoutes" style="text-transform: uppercase;"><strong>Get Different routes</strong></label>
                <br /><br />

                Enter Academy: <asp:TextBox ID="GetAcademies" runat="server" MaxLength="2" onkeydown="return /[a-e]/i.test(event.key)" AutoPostBack = "true"  OnTextChanged="Result_TextChanged"></asp:TextBox> <%--OnTextChanged="GetAcademies_TextChanged"--%>
                <br /><br />

                Enter Max Stops: <asp:TextBox ID="maxStops" runat="server" AutoPostBack = "true"></asp:TextBox>
                <br /><br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
                <br /><br />
                <%--Total Routes: <asp:TextBox ID="TotalRoutes" runat="server" enabled="false" AutoPostBack = "true"></asp:TextBox>--%>
                <asp:label for="GetTotalRoutes" id="GetTotalRoutes" runat="server" style="color:red;"></asp:label>
                <br /><br />
                
            </div><br /><br />



            <div id="thirdDiv">
                <label for="forShortestRoutes"style="text-transform: uppercase;"><strong>Get shortest route(in terms of distance) </strong></label>
                <br /><br />
                Enter Academy: <asp:TextBox ID="GetStartEndAcademy" runat="server" MaxLength="2" onkeydown="return /[a-e]/i.test(event.key)" AutoPostBack = "true" OnTextChanged="Result_TextChanged"></asp:TextBox>
                <br /><br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Submit" />
                <br /><br />
                <%--Shortest Routes Distance: <asp:TextBox ID="ShortestRouteDistance" runat="server" enabled="false" AutoPostBack = "true" ></asp:TextBox>--%>
                <asp:label id="GetShortestRouteDistance" runat="server" style="color:red;"></asp:label>
                <br /><br />
                
            </div><br /><br />

            <div id="fourthDiv">

                <label for="forRoutes"style="text-transform: uppercase;"><strong>Get different routes based on distance </strong></label>
                <br /><br />
                Enter Academy: 
                <asp:TextBox ID="GetAcademyDetails" runat="server" MaxLength="2" onkeydown="return /[a-e]/i.test(event.key)" AutoPostBack = "true" OnTextChanged="Result_TextChanged"></asp:TextBox>
                <br /><br />

                <label for="maxDistance">distance < </label>
                <asp:TextBox ID="inputMaxDistance" runat="server" AutoPostBack = "true"></asp:TextBox>
                <br /><br />

                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Submit" />
                <br /><br />

                <%--Total Routes: <asp:TextBox ID="TotalRoutesBasedOnDistance" runat="server" enabled="false" AutoPostBack = "true" ></asp:TextBox>--%>
                <asp:label id="GetTotalRoutesBasedOnDistance" runat="server" style="color:red;"></asp:label>
                <br /><br />           
            </div>
            </div>
    </form>
      
  </body>
</html>

