import {
  Box,
  Typography,
  FormControl,
  Select,
  MenuItem,
  Button,
} from "@mui/material";

import KeyboardArrowLeftIcon from "@mui/icons-material/KeyboardArrowLeft";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import SearchIcon from "@mui/icons-material/Search";
import FileDownloadOutlinedIcon from "@mui/icons-material/FileDownloadOutlined";
import PrintOutlinedIcon from "@mui/icons-material/PrintOutlined";

const AttendanceFilters = () => {
  return (
    <>
      <Box
        display="flex"
        justifyContent="space-between"
        alignItems="center"
        mb={3}
      >
        <Box>
          <Typography fontSize={30} fontWeight={700}>
            ATTENDANCE SUMMARY
          </Typography>

          <Typography color="gray">
            View attendance details for the selected month
          </Typography>
        </Box>

        <Box display="flex" gap={2}>
          <Button
            variant="outlined"
            startIcon={<KeyboardArrowLeftIcon />}
            endIcon={<KeyboardArrowRightIcon />}
          >
            July 2026
          </Button>

          <Button
            variant="outlined"
            startIcon={<FileDownloadOutlinedIcon />}
          >
            Export
          </Button>

          <Button
            variant="outlined"
            startIcon={<PrintOutlinedIcon />}
          >
            Print
          </Button>
        </Box>
      </Box>

      <Box
        display="flex"
        gap={2}
        mb={3}
      >
        <FormControl sx={{ width: 250 }}>
          <Select defaultValue="Mahesh">
            <MenuItem value="Mahesh">
              Mahesh S (EMP1001)
            </MenuItem>
          </Select>
        </FormControl>

        <FormControl sx={{ width: 180 }}>
          <Select defaultValue="All">
            <MenuItem value="All">
              All Departments
            </MenuItem>
          </Select>
        </FormControl>

        <FormControl sx={{ width: 180 }}>
          <Select defaultValue="All">
            <MenuItem value="All">
              All Locations
            </MenuItem>
          </Select>
        </FormControl>

        <Button
          variant="contained"
          startIcon={<SearchIcon />}
        >
          Search
        </Button>
      </Box>
    </>
  );
};

export default AttendanceFilters;