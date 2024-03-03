import React from 'react'
import axios from 'axios';
import { useState} from 'react';
import '../Style/CreateUpdateComponent.css';
import { useNavigate } from 'react-router-dom';
function LoginComponent() {
  const [LoginDetails, setLoginDetails] = useState({ UserEmail: '', UserPassword: '' });
  const usenavigate=useNavigate();
  const [useremailerror,setuseremailerror]=useState('');
  const [userpwderror,setuserpwderror]=useState('');
  const [servererror,setservererror]=useState('');
  const CheckLogin=(LoginDetails)=>{
    setuseremailerror('');
        setuserpwderror('');
    if(LoginDetails.UserEmail==''||LoginDetails.UserPassword==''){
      if(LoginDetails.UserEmail==''){
        setuseremailerror("Please enter a email")
      }
      if(LoginDetails.UserPassword==''){
        setuserpwderror("Please enter a password")
      }
    }else{
      axios.post(`/apiGateway/CheckLogin`,LoginDetails).then((response) => {
        setservererror('');
        var json=response.data;
        if(json.account==true&& json.emailstatus== true&& json.passwordstatus== true){
          console.log("success");
          usenavigate('/home')
        }else{
          if(json.account==false){
            setservererror("No account in this email")
          }
          else if(json.emailstatus==false){
            setservererror("Wrong email")
          }
          else if(json.passwordstatus==false){
            setservererror("Wrong Password")
          }
        }
  
      }).catch((error) => {
        console.error("error occured in fetch effect")
      });
    }
    
  }
  return (
    <div>
      <section className='container'>
        <div className='logincontainer'>
          <form className="row">
          <div className='mb-5'>Welcome to Movie Center</div>
          <div className='text-danger'>{servererror}</div>

            <div className="col-12">
              <div className='text-danger'>{useremailerror}</div>
              <label for="UserEmail" className="form-label">Enter a email</label>
              <input type="text" className="form-control ms-5 me-5 w-75" id="UserEmail" value={LoginDetails.UserEmail}
                onChange={(e) => setLoginDetails({ ...LoginDetails, UserEmail: e.target.value })}
              />
            </div><br />
            <div className="col-12">
            <div className='text-danger'>{userpwderror}</div>

              <label for="UserPassword" className="form-label">Enter a password</label>
              <input type="text" className="form-control ms-5 me-5 w-75" id="UserPassword" value={LoginDetails.UserPassword}
                onChange={(e) => setLoginDetails({ ...LoginDetails, UserPassword: e.target.value })}
              />
            </div>
            <div className="col-12 mt-5">
              <button type="submit" onClick={(e) => { CheckLogin(LoginDetails); e.preventDefault() }} className="btn btn-primary">Login</button>
            </div>
            <div className="col-12 mt-3">
              <a onClick={(e) => { usenavigate("/register"); e.preventDefault() }} className="">Register</a>
            </div>
          </form>
        </div>

      </section>

    </div>
  )
}

export default LoginComponent