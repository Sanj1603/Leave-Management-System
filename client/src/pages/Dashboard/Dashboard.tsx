import { useState } from "react";
import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from "@mui/material";
import "./Dashboard.css";
import Cards from "../../components/Card/Card";


const Dashboard = () => {
  const user =
    JSON.parse(localStorage.getItem("user") || "null") ||
    JSON.parse(sessionStorage.getItem("user") || "null");

  const [isCheckedIn, setIsCheckedIn] = useState(
    localStorage.getItem("isCheckedIn") === "true"
  );

  const [openEmployeeModal, setOpenEmployeeModal] = useState(false);

  const [employeeData, setEmployeeData] = useState({
    name: "",
    role: "",
    email: "",
    phone: "",
    address: "",
    password: "",
    department: "",
    designation: "",
    dateOfJoining: "",
    manager: "",
  });

  if (!user) return null;

  const handleCheckIn = () => {
    setIsCheckedIn(true);
    localStorage.setItem("isCheckedIn", "true");
    alert("Checked In Successfully");
  };

  const handleCheckOut = () => {
    setIsCheckedIn(false);
    localStorage.setItem("isCheckedIn", "false");
    alert("Checked Out Successfully");
  };

  const handleOpenEmployeeModal = () => {
    setOpenEmployeeModal(true);
  };

  const handleCloseEmployeeModal = () => {
    setOpenEmployeeModal(false);
  };

const handleInputChange = (
  e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement> | any
) => {
  const { name, value } = e.target;

  setEmployeeData((prev) => ({
    ...prev,
    [name]: value,
  }));
};

  const handleCreateEmployee = () => {
    console.log("Employee Data:", employeeData);

    // API Call Here
    // axios.post("/api/employees", employeeData)

    alert("Employee Created Successfully");

    setEmployeeData({
      name: "",
      role: "",
      email: "",
      phone: "",
      address: "",
      password: "",
      department: "",
      designation: "",
      dateOfJoining: "",
      manager: "",
    });

    setOpenEmployeeModal(false);
  };

  return (
    <div className="dashboard">
      <div className="dashboard-content">
        <div className="card">
          <div className="dashboard-header">
            <div className="user-info">
              <h2>Welcome, {user.name}</h2>
              <h3>Role: {user.role}</h3>
            </div>

            <div
              className="attendance-actions"
              style={{
                display: "flex",
                gap: "10px",
              }}
            >
              {user.role === "Admin" && (
                <Button
                  variant="contained"
                  color="success"
                  onClick={handleOpenEmployeeModal}
                >
                  Create Employee
                </Button>
              )}

              <Button
                variant="contained"
                className="checkin-btn"
                onClick={handleCheckIn}
                disabled={isCheckedIn}
              >
                Check In
              </Button>

              <Button
                variant="contained"
                className="checkout-btn"
                onClick={handleCheckOut}
                disabled={!isCheckedIn}
              >
                Check Out
              </Button>
            </div>
          </div>

          <Cards role={user.role} />
        </div>
      </div>

      {/* Create Employee Dialog */}
      <Dialog
        open={openEmployeeModal}
        onClose={handleCloseEmployeeModal}
        maxWidth="md"
        fullWidth
      >
        <DialogTitle>Create Employee</DialogTitle>

        <DialogContent
          sx={{
            display: "grid",
            gridTemplateColumns: "1fr 1fr",
            gap: 2,
            mt: 1,
          }}
        >
          <TextField
            label="Name"
            name="name"
            value={employeeData.name}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Email"
            name="email"
            type="email"
            value={employeeData.email}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Phone Number"
            name="phone"
            value={employeeData.phone}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Address"
            name="address"
            value={employeeData.address}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Password"
            type="password"
            name="password"
            value={employeeData.password}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Department"
            name="department"
            value={employeeData.department}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Designation"
            name="designation"
            value={employeeData.designation}
            onChange={handleInputChange}
            fullWidth
          />

          <TextField
            label="Date Of Joining"
            type="date"
            name="dateOfJoining"
            value={employeeData.dateOfJoining}
            onChange={handleInputChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />

          <FormControl fullWidth>
            <InputLabel>Role</InputLabel>
            <Select
              name="role"
              value={employeeData.role}
              onChange={handleInputChange}
              label="Role"
            >
              <MenuItem value="Admin">Admin</MenuItem>
              <MenuItem value="Manager">Manager</MenuItem>
              <MenuItem value="Employee">Employee</MenuItem>
            </Select>
          </FormControl>

          <FormControl fullWidth>
            <InputLabel>Manager</InputLabel>
            <Select
              name="manager"
              value={employeeData.manager}
              onChange={handleInputChange}
              label="Manager"
            >
              <MenuItem value="John Doe">John Doe</MenuItem>
              <MenuItem value="Peter Smith">Peter Smith</MenuItem>
              <MenuItem value="Michael Brown">
                Michael Brown
              </MenuItem>
            </Select>
          </FormControl>
        </DialogContent>

        <DialogActions>
          <Button onClick={handleCloseEmployeeModal}>
            Cancel
          </Button>

          <Button
            variant="contained"
            color="primary"
            onClick={handleCreateEmployee}
          >
            Create Employee
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default Dashboard;