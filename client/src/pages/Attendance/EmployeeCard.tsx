import {
  Avatar,
  Box,
  Card,
  Typography,
} from "@mui/material";

import { employee } from "./attendenceData";

const EmployeeCard = () => {
  return (
    <Card
      sx={{
        p: 3,
        mb: 3,
        display: "flex",
        alignItems: "center",
      }}
    >
      <Avatar
        src={employee.image}
        sx={{
          width: 70,
          height: 70,
          mr: 3,
        }}
      />

      <Box>

        <Typography
          fontWeight="bold"
          fontSize={20}
        >
          {employee.name} ({employee.id})
        </Typography>

        <Typography>
          {employee.designation}
        </Typography>

        <Typography>
          {employee.department}
        </Typography>

        <Typography mt={1}>
          Date of Joining :
          <b> {employee.joiningDate}</b>
        </Typography>

      </Box>

    </Card>
  );
};

export default EmployeeCard;