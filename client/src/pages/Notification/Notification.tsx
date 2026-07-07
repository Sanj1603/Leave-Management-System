import { Paper, Typography } from "@mui/material";

const Notification = () => {
  return (
    <Paper
      elevation={2}
      sx={{
        padding: "35px",
        borderRadius: "12px",
        boxShadow: "0 2px 10px rgba(0,0,0,.08)",
      }}
    >
      <Typography
        variant="h4"
        sx={{
          color: "#1A3E7A",
          fontWeight: "bold",
          mb: 1,
        }}
      >
        Notifications
      </Typography>

      <Typography
        variant="body2"
        sx={{
          color: "#666",
          mt: 3,
          fontSize: "15px",
        }}
      >
        All your notifications appear here.
      </Typography>
    </Paper>
  );
};

export default Notification;