import React, { useState } from 'react'
import './login.css';

function LoginForm({ Login, error }) {
    const [details, setDetails] = useState({ name: "", email: "", password: "" });

    const submitHandler = e => {
        e.preventDefault();
        Login(details);
    }

    return (
        <form onSubmit={submitHandler}>
            <div className='form-inner'>
                
                <h2>登录</h2>
                {(error !== "") ? (<div className='error'>{error}</div>) : ""}
                <div className="form-group">
                    <label htmlFor="name"> 姓名: </label>
                    <input type="text" name='name' id='name' onChange={e => setDetails({ ...details, name: e.target.value })} value={details.name} />
                </div>
                <div className="form-group">
                    <label htmlFor="email">邮箱: </label>
                    <input type="text" name='email' id='email' onChange={e => setDetails({ ...details, email: e.target.value })} value={details.email} />

                </div>
                <div className="form-group">
                    <label htmlFor="password">密码: </label>
                    <input type='password' name='password' id='password' onChange={e => setDetails({ ...details, password: e.target.value })} value={details.password} />

                </div>
                <input type="submit" value="确定登录" />

            </div>
        </form>
    )
}

export default LoginForm
