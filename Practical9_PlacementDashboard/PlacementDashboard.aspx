
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlacementDashboard.aspx.cs" Inherits="Practical9_PlacementDashboard.PlacementDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Placement Dashboard</title>
    <style>
        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background: #fff8f1;
            color: #292524;
        }

        .sidebar {
            width: 230px;
            height: 100vh;
            background: #292524;
            position: fixed;
            padding: 28px 18px;
            color: white;
        }

        .logo {
            font-size: 21px;
            font-weight: bold;
            margin-bottom: 45px;
            color: #ffad62;
        }

        .menu {
            padding: 14px;
            margin: 10px 0;
            border-radius: 7px;
            background: #44403c;
            cursor: pointer;
        }

        .menu:first-of-type {
            background: #ea7c24;
        }

        .main {
            margin-left: 230px;
            padding: 30px;
        }

        .topbar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 30px;
        }

        h1 {
            margin: 0;
            font-size: 27px;
            color: #9a4512;
        }

        .subtitle {
            color: #9a8b7d;
            margin-top: 8px;
        }

        .admin {
            background: white;
            padding: 12px 20px;
            border-radius: 8px;
            border: 1px solid #f3dfcc;
            font-weight: bold;
        }

        .cards {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            gap: 18px;
            margin-bottom: 30px;
        }

        .card {
            background: white;
            padding: 23px;
            border-radius: 12px;
            box-shadow: 0 3px 12px #eadaca;
            border-top: 4px solid #ed8a32;
        }

        .card p {
            color: #9a8b7d;
            margin: 0 0 12px;
        }

        .card h2 {
            margin: 0;
            font-size: 28px;
            color: #b45309;
        }

        .section {
            background: white;
            padding: 25px;
            border-radius: 12px;
            box-shadow: 0 3px 12px #eadaca;
        }

        .section-head {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

        .section h2 {
            margin: 0;
            font-size: 20px;
            color: #9a4512;
        }

        .search {
            padding: 10px;
            border: 1px solid #f0c9a5;
            border-radius: 6px;
            outline: none;
        }

        .search:focus {
            border-color: #e87924;
        }

        .search-btn {
            padding: 10px 18px;
            background: #e87924;
            color: white;
            border: 0;
            border-radius: 6px;
            cursor: pointer;
        }

        .search-btn:hover {
            background: #c45b12;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
        }

        .grid th {
            background: #d96b1b;
            color: white;
            padding: 14px;
            text-align: left;
        }

        .grid td {
            padding: 14px;
            border-bottom: 1px solid #f4e8dc;
        }

        .grid tr:hover {
            background: #fff3e7;
        }

        .footer {
            text-align: center;
            color: #9a8b7d;
            margin-top: 25px;
            font-size: 13px;
        }

        @media(max-width: 900px) {
            .cards {
                grid-template-columns: repeat(2, 1fr);
            }

            .sidebar {
                width: 170px;
            }

            .main {
                margin-left: 170px;
                padding: 18px;
            }
        }

        @media(max-width: 600px) {
            .sidebar {
                display: none;
            }

            .main {
                margin-left: 0;
            }

            .cards {
                grid-template-columns: 1fr;
            }

            .section {
                overflow-x: auto;
            }

            .grid {
                min-width: 600px;
            }

            .topbar {
                gap: 15px;
                flex-wrap: wrap;
            }
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="sidebar">
            <div class="logo">PLACEMENT PORTAL</div>
            <div class="menu">Dashboard</div>
            <div class="menu">Student Records</div>
            <div class="menu">Company Details</div>
            <div class="menu">Placement Reports</div>
        </div>

        <div class="main">

            <div class="topbar">
                <div>
                    <h1>Placement Dashboard</h1>
                    <div class="subtitle">Welcome to Student Placement Management System</div>
                </div>
                <div class="admin">Administrator</div>
            </div>

            <div class="cards">
                <div class="card">
                    <p>Total Students</p>
                    <h2>5</h2>
                </div>

                <div class="card">
                    <p>Selected Students</p>
                    <h2>4</h2>
                </div>

                <div class="card">
                    <p>Pending Students</p>
                    <h2>1</h2>
                </div>

                <div class="card">
                    <p>Average Package</p>
                    <h2>4.2 LPA</h2>
                </div>
            </div>

            <div class="section">
                <div class="section-head">
                    <h2>Student Placement Records</h2>
                    <asp:TextBox ID="txtSearch" runat="server"
                        CssClass="search"
                        placeholder="Search student..." />
                </div>

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="search-btn" />

                <br /><br />

                <asp:GridView ID="GridView1" runat="server"
                    CssClass="grid"
                    AutoGenerateColumns="False"
                    DataSourceID="SqlDataSource1"
                    EmptyDataText="No placement records found.">

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="Company" HeaderText="Company" />
                        <asp:BoundField DataField="Package" HeaderText="Package (LPA)" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>

                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:PlacementDB %>"
                    SelectCommand="SELECT * FROM Placement">
                </asp:SqlDataSource>

            </div>

            <div class="footer">
                Placement Management System | .NET Technologies Practical 9
            </div>

        </div>

    </form>
</body>
</html>
