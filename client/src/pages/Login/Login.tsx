import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { mockUsers } from "../../mock/users";

interface LoginForm {
  email: string;
  password: string;
}
function Login() {
    const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginForm>();

const onSubmit = (data: LoginForm) => {
  const user = mockUsers.find(
    (u) =>
      u.email === data.email &&
      u.password === data.password
  );

  if (user) {
    navigate("/dashboard");
  } else {
    alert("Invalid email or password");
  }
};

  return (
    <div className="login-container">
      <h1>Employee Leave Management System</h1>
      <h2>Login</h2>

      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label>Email Address</label>

          <input
            type="email"
            placeholder="Enter your email"
            {...register("email", {
              required: "Email is required",
              pattern: {
                value: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                message: "Invalid email format",
              },
            })}
          />

          {errors.email && (
            <p>{errors.email.message}</p>
          )}
        </div>

        <div>
          <label>Password</label>

          <input
            type="password"
            placeholder="Enter your password"
            {...register("password", {
              required: "Password is required",
            })}
          />

          {errors.password && (
            <p>{errors.password.message}</p>
          )}
        </div>

        <div>
          <a href="#">Forgot Password?</a>
        </div>

        <button type="submit">Login</button>
      </form>
    </div>
  );
}

export default Login;