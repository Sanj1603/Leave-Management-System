import "./Attendance.css";

import AttendanceFilters from "./AttendanceFilters";
import EmployeeCard from "./EmployeeCard";
import AttendanceSummary from "./AttendanceSummary";
import AttendanceTable from "./AttendanceTable";
import AttendanceLegend from "./AttendanceLegend";

const Attendance = () => {

    return (

        <div className="attendance-page">

            <AttendanceFilters />

            <EmployeeCard />

            <AttendanceSummary />

            <AttendanceTable />

            <AttendanceLegend />

        </div>

    );

};

export default Attendance;