import "./Dashboard.css";
import Cards from "../../components/Card/Card";

const Dashboard = () => {
  const user =
    JSON.parse(localStorage.getItem("user") || "null") ||
    JSON.parse(sessionStorage.getItem("user") || "null");

  if (!user) return null;

  return (
    <div className="dashboard">
      <h1>Leave Management System</h1>

      <div className="dashboard-content">
        <div className="card">
          <h2>Welcome, {user.name}</h2>

          <h3>Role: {user.role}</h3>

          <Cards role={user.role} />
        </div>
      </div>
    </div>
  );
};

export default Dashboard;