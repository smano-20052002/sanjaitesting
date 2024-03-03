import React, { useState } from 'react'
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useEffect } from 'react';
import '../Style/CreateUpdateComponent.css'
function HomeComponent() {
  const [totalmovie,settotalmovie]=useState('0');
  useEffect(() => {
    axios.get('/apiGateway/TotalMovie').then((response) => {
        settotalmovie(response.data);        
    }).catch((error) => {
        console.error("error occured in fetch effect")
    });
    
}, []);
  return (
    <div>
      <div className='Total btn btn-outline-info d-flex  w-25 ms-4 mt-5'>
        Total Movie <br/>
        {totalmovie}
      </div>
      <div className='d-flex'>
        <div><Link to='/create' className='Homebtn btn btn-outline-success d-flex '>Add Movie</Link>
        </div>
        <div>
        <Link to='/list' className='Homebtn btn btn-outline-warning d-flex '>List Movie</Link>
        
        </div>
      </div>
    </div>
  )
}

export default HomeComponent