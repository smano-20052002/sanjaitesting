import React, { useState } from 'react'
import axios from 'axios';
import '../Style/CreateUpdateComponent.css';
import { useNavigate } from 'react-router-dom';
function RegisterComponent() {
    const [RegisterDetails, setRegisterDetails] = useState({ UserEmail: '', UserPassword: '', UserName: '' });
    const usenavigate = useNavigate();
    const [error, setError] = useState('');
    const [useremailerror,setuseremailerror]=useState('');
  const [userpwderror,setuserpwderror]=useState('');
  const [usernameerror,setusernameerror]=useState('');
    const Register = (RegisterDetails) => {
        setuseremailerror('');
        setusernameerror('');
        setuserpwderror('');
        if(RegisterDetails.UserEmail==''||RegisterDetails.UserPassword==''||RegisterDetails.UserName==''){
            if(RegisterDetails.UserEmail==''){
              setuseremailerror("Please enter a email")
            }
            if(RegisterDetails.UserPassword==''){
              setuserpwderror("Please enter a password")
            }
            if(RegisterDetails.UserName==''){
                setusernameerror("Please enter a username")
              }
          }else{axios.post(`/apiGateway/Register`, RegisterDetails).then((response) => {
            if (response.data.Exists) {
                setError("Email is already exists");
            } else {
                usenavigate('/home');
            }
        }).catch((error) => {
            console.error("error occured in fetch effect")
        });
    }
    }
    return (
        <div>
            <section className='container'>
                <div className='Registercontainer'>
                    <form className="row">
                        <div className='mb-5'>Welcome to Movie Center</div>
                        <div className='text-danger m-2'>{error}</div>
                        <div className="col-12">
                        <div className='text-danger'>{usernameerror}</div>

                            <label for="UserName" className="form-label">Enter a name</label>
                            <input type="text" className="form-control ms-5 me-5 w-75" id="UserName" value={RegisterDetails.UserName}
                                onChange={(e) => setRegisterDetails({ ...RegisterDetails, UserName: e.target.value })}
                            />
                        </div><br />
                        <div className="col-12">
                        <div className='text-danger'>{useremailerror}</div>

                            <label for="UserEmail" className="form-label">Enter a email</label>
                            <input type="text" className="form-control ms-5 me-5 w-75" id="UserEmail" value={RegisterDetails.UserEmail}
                                onChange={(e) => setRegisterDetails({ ...RegisterDetails, UserEmail: e.target.value })}
                            />
                        </div><br />
                        <div className="col-12">
                        <div className='text-danger'>{userpwderror}</div>

                            <label for="UserPassword" className="form-label">Enter a password</label>
                            <input type="text" className="form-control ms-5 me-5 w-75" id="UserPassword" value={RegisterDetails.UserPassword}
                                onChange={(e) => setRegisterDetails({ ...RegisterDetails, UserPassword: e.target.value })}
                            />
                        </div>
                        <div className="col-12 mt-5">
                            <button type="submit" onClick={(e) => { Register(RegisterDetails); e.preventDefault() }} className="btn btn-primary">Register</button>
                        </div>
                        <div className="col-12 mt-3">
                            <a onClick={(e) => { usenavigate("/"); e.preventDefault() }} className="">Login</a>
                        </div>
                    </form>
                </div>

            </section>

        </div>
    )
}

export default RegisterComponent