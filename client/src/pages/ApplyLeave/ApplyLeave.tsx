import { useState } from "react";
import {
  Box,
  Button,
  Grid,
  MenuItem,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import "./ApplyLeave.css";

const leaveTypes = [
  "Casual Leave",
  "Sick Leave",
  "Earned Leave",
  "Work From Home",
];

const ApplyLeave = () => {
  const [leaveType, setLeaveType] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [reason, setReason] = useState("");

  const calculateDays = () => {
    if (!startDate || !endDate) return "";

    const start = new Date(startDate);
    const end = new Date(endDate);

    const diff =
      (end.getTime() - start.getTime()) /
      (1000 * 60 * 60 * 24);

    return diff >= 0 ? diff + 1 : "";
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (!leaveType || !startDate || !endDate || !reason) {
      alert("Please fill all fields.");
      return;
    }

    alert("Leave Applied Successfully (Mock)");

    setLeaveType("");
    setStartDate("");
    setEndDate("");
    setReason("");
  };

  const handleReset = () => {
    setLeaveType("");
    setStartDate("");
    setEndDate("");
    setReason("");
  };

  return (
    <Paper elevation={2} className="apply-card">

      <Typography variant="h4" className="page-title">
        Apply Leave
      </Typography>

      <Typography className="page-subtitle">
        Submit a leave request for approval.
      </Typography>

      <Box
        component="form"
        onSubmit={handleSubmit}
        className="leave-form"
      >

        <Grid container spacing={3}>

          <Grid size={{ xs: 12, md: 6 }}>
            <TextField
              select
              fullWidth
              label="Leave Type"
              value={leaveType}
              onChange={(e) =>
                setLeaveType(e.target.value)
              }
            >
              {leaveTypes.map((type) => (
                <MenuItem
                  key={type}
                  value={type}
                >
                  {type}
                </MenuItem>
              ))}
            </TextField>
          </Grid>

          <Grid size={{ xs: 12, md: 6 }}>
            <TextField
              fullWidth
              label="Number of Days"
              value={calculateDays()}
              InputProps={{
                readOnly: true,
              }}
            />
          </Grid>

          <Grid size={{ xs: 12, md: 6 }}>
            <TextField
              fullWidth
              type="date"
              label="Start Date"
              value={startDate}
              onChange={(e) =>
                setStartDate(e.target.value)
              }
              InputLabelProps={{
                shrink: true,
              }}
            />
          </Grid>

          <Grid size={{ xs: 12, md: 6 }}>
            <TextField
              fullWidth
              type="date"
              label="End Date"
              value={endDate}
              onChange={(e) =>
                setEndDate(e.target.value)
              }
              InputLabelProps={{
                shrink: true,
              }}
            />
          </Grid>

          <Grid size={12}>
            <TextField
              fullWidth
              multiline
              rows={5}
              label="Reason"
              value={reason}
              onChange={(e) =>
                setReason(e.target.value)
              }
            />
          </Grid>

        </Grid>

        <div className="button-group">

          <Button
            variant="outlined"
            onClick={handleReset}
          >
            Reset
          </Button>

          <Button
            variant="contained"
            type="submit"
          >
            Apply Leave
          </Button>

        </div>

      </Box>

    </Paper>
  );
};

export default ApplyLeave;