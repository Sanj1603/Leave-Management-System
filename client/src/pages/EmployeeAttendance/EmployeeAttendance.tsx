import { useState } from "react";
import {
  Box,
  Button,
  Paper,
  TextField,
  Typography,
  InputAdornment,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";

import "../Attendance/Attendance.css";

import EmployeeCard from "../Attendance/EmployeeCard";
import AttendanceSummary from "../Attendance/AttendanceSummary";
import AttendanceTable from "../Attendance/AttendanceTable";
import AttendanceLegend from "../Attendance/AttendanceLegend";

import { mockUsers } from "../../mock/users";

const EmployeeAttendance = () => {
  const [searchText, setSearchText] = useState("");
  const [searchedUser, setSearchedUser] = useState<any>(null);
  const [error, setError] = useState("");

  const handleSearch = () => {
    const value = searchText.trim().toLowerCase();

    if (!value) {
      setError("Please enter employee name or email.");
      setSearchedUser(null);
      return;
    }

    const user = mockUsers.find(
      (u) =>
        u.name.toLowerCase().includes(value) ||
        u.email.toLowerCase().includes(value)
    );

    if (user) {
      setSearchedUser(user);
      setError("");
    } else {
      setSearchedUser(null);
      setError("Employee not found.");
    }
  };

  return (
    <div className="attendance-page">
      {/* Header */}
      <Box mb={3}>
        <Typography fontSize={30} fontWeight={700}>
          EMPLOYEE ATTENDANCE
        </Typography>

        <Typography color="gray">
          Search an employee or manager to view attendance details.
        </Typography>
      </Box>

      {/* Search Card */}
      <Paper
        elevation={2}
        sx={{
          p: 3,
          mb: 3,
          borderRadius: 2,
        }}
      >
        <Box
          display="flex"
          gap={2}
          flexWrap="wrap"
          alignItems="center"
        >
          <TextField
            fullWidth
            label="Search Employee Name or Email"
            value={searchText}
            onChange={(e) => setSearchText(e.target.value)}
            onKeyDown={(e) => {
              if (e.key === "Enter") {
                handleSearch();
              }
            }}
            InputProps={{
              startAdornment: (
                <InputAdornment position="start">
                  <SearchIcon />
                </InputAdornment>
              ),
            }}
          />

          <Button
            variant="contained"
            size="large"
            onClick={handleSearch}
            sx={{
              minWidth: 130,
              height: 56,
            }}
          >
            Search
          </Button>
        </Box>

        {error && (
          <Typography
            color="error"
            mt={2}
            fontWeight={500}
          >
            {error}
          </Typography>
        )}
      </Paper>

      {/* Attendance Details */}

      {searchedUser && (
        <>
          <EmployeeCard user={searchedUser} />

          <AttendanceSummary />

          <AttendanceTable />

          <AttendanceLegend />
        </>
      )}
    </div>
  );
};

export default EmployeeAttendance;