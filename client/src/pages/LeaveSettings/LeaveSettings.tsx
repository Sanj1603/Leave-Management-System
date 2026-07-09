import  { useState } from "react";
import {
  Box,
  Typography,
  Paper,
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  TableContainer,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  IconButton,
} from "@mui/material";

import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import type { LeaveType} from "../../types";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import { useNavigate } from "react-router-dom";



const LeaveSettings = () => {
  const navigate = useNavigate();
  const [leaveTypes, setLeaveTypes] = useState<LeaveType[]>([
    {
      id: 1,
      leaveType: "Casual Leave",
      totalLeaves: 10,
    },
    {
      id: 2,
      leaveType: "Sick Leave",
      totalLeaves: 15,
    },
    {
      id: 3,
      leaveType: "Earned Leave",
      totalLeaves: 20,
    },
  ]);

  const [open, setOpen] = useState(false);

  const [isEdit, setIsEdit] = useState(false);

  const [currentId, setCurrentId] = useState<number | null>(null);

  const [leaveType, setLeaveType] = useState("");

  const [totalLeaves, setTotalLeaves] = useState("");

  const handleAdd = () => {
    setIsEdit(false);
    setCurrentId(null);
    setLeaveType("");
    setTotalLeaves("");
    setOpen(true);
  };

  const handleEdit = (leave: LeaveType) => {
    setIsEdit(true);
    setCurrentId(leave.id);
    setLeaveType(leave.leaveType);
    setTotalLeaves(leave.totalLeaves.toString());
    setOpen(true);
  };

  const handleSave = () => {
    if (!leaveType || !totalLeaves) return;

    if (isEdit) {
      setLeaveTypes((prev) =>
        prev.map((item) =>
          item.id === currentId
            ? {
                ...item,
                leaveType,
                totalLeaves: Number(totalLeaves),
              }
            : item
        )
      );
    } else {
      setLeaveTypes((prev) => [
        ...prev,
        {
          id: Date.now(),
          leaveType,
          totalLeaves: Number(totalLeaves),
        },
      ]);
    }

    setOpen(false);
  };

  const handleDelete = (id: number) => {
    setLeaveTypes((prev) => prev.filter((item) => item.id !== id));
  };

  return (
    <Box p={4}>
      <Button
  startIcon={<ArrowBackIcon />}
  variant="outlined"
  sx={{ mb: 2 }}
  onClick={() => navigate("/dashboard")}
>
</Button>

      <Box
        display="flex"
        justifyContent="space-between"
        alignItems="center"
        mb={3}
      >
        <Typography variant="h4">
          Leave Settings
        </Typography>

        <Button
          variant="contained"
          startIcon={<AddIcon />}
          onClick={handleAdd}
        >
          Add Leave Type
        </Button>
      </Box>

      <TableContainer component={Paper}>
        <Table>

          <TableHead>
            <TableRow>
              <TableCell>
                <b>Leave Type</b>
              </TableCell>

              <TableCell>
                <b>Total Leaves</b>
              </TableCell>

              <TableCell align="center">
                <b>Actions</b>
              </TableCell>
            </TableRow>
          </TableHead>

          <TableBody>

            {leaveTypes.map((leave) => (
              <TableRow key={leave.id}>

                <TableCell>
                  {leave.leaveType}
                </TableCell>

                <TableCell>
                  {leave.totalLeaves}
                </TableCell>

                <TableCell align="center">

                  <IconButton
                    color="primary"
                    onClick={() => handleEdit(leave)}
                  >
                    <EditIcon />
                  </IconButton>

                  <IconButton
                    color="error"
                    onClick={() => handleDelete(leave.id)}
                  >
                    <DeleteIcon />
                  </IconButton>

                </TableCell>

              </TableRow>
            ))}

          </TableBody>

        </Table>
      </TableContainer>

      <Dialog
        open={open}
        onClose={() => setOpen(false)}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle>
          {isEdit ? "Edit Leave Type" : "Add Leave Type"}
        </DialogTitle>

        <DialogContent>

          <TextField
            label="Leave Type"
            fullWidth
            margin="normal"
            value={leaveType}
            onChange={(e) => setLeaveType(e.target.value)}
          />

          <TextField
            label="Total Leaves"
            type="number"
            fullWidth
            margin="normal"
            value={totalLeaves}
            onChange={(e) => setTotalLeaves(e.target.value)}
          />

        </DialogContent>

        <DialogActions>

          <Button onClick={() => setOpen(false)}>
            Cancel
          </Button>

          <Button
            variant="contained"
            onClick={handleSave}
          >
            Save
          </Button>

        </DialogActions>
      </Dialog>

    </Box>
  );
};

export default LeaveSettings;