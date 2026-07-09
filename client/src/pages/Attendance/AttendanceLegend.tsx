import { Box, Chip, Typography } from "@mui/material";

const AttendanceLegend = () => {
  return (
    <Box
      sx={{
        mt: 3,
        display: "flex",
        alignItems: "center",
        gap: 2,
        flexWrap: "wrap",
      }}
    >
      <Typography fontWeight="bold">
        Legend :
      </Typography>

      <Chip
        label="P - Present"
        color="success"
      />

      <Chip
        label="A - Absent"
        color="error"
      />

      <Chip
        label="L - Leave"
        color="primary"
      />

      <Chip
        label="HD - Half Day"
        color="warning"
      />

      <Chip
        label="WO - Weekly Off"
        color="default"
      />
    </Box>
  );
};

export default AttendanceLegend;