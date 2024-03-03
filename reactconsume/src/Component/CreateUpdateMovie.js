import React from 'react'
import { useState, useEffect } from 'react';
import { useParams ,useNavigate} from "react-router-dom";
import axios from 'axios';
import '../Style/CreateUpdateComponent.css';
function CreateUpdateMovie() {
  const [btnname, setBtnname] = useState('Add Movie');
  const [newMovie, setNewMovie] = useState({ movieId: 0, movieName: '', movieType: '',movieLanguage: '',movieDurations:'' });
  const [isUpdate, setIsUpdate] = useState(false);
  const usenavigate=useNavigate();
  const [langerror,setlangerror]=useState('');
  const [duraerror,setduraerror]=useState('');
  const [typeerror,settypeerror]=useState('');
  const [nameerror,setnameerror]=useState('');
  const routeParams = useParams();
  const addupdateProduct = (id) => {
    if (isUpdate === true) {
      
        axios.put('/apiGateway/UpdateMovie', newMovie)
        .then((response) => {

          console.log('Update successful:', response.data);
          usenavigate('/list')
        })
        .catch((error) => {

          console.error('Error updating data:', error);
        });
      

      setIsUpdate(false)

    } else {
      
          axios.post('/apiGateway/AddMovie', newMovie).then((response) => {
            console.log(response.data);
            usenavigate('/list')
          });
        
     
    }
    setNewMovie({ movieId: 0, movieName: '', movieType: '',movieLanguage: '',movieDurations:'' });
  };
  useEffect(() => {
    const id = routeParams.id;
    if (id >= 1) {
      setIsUpdate(true);
      setBtnname('Update');
      axios.get(`/apiGateway/FetchMovie/${id}`).then((response) => {
        setNewMovie(response.data);
        console.log(response.data);
      }).catch((error) => {
        console.error("error occured in fetch effect")
      });
    }
  }, []);
  return (
    <div>
      <section className='container'>
        <div className='centeritem'>
        <form className="row">
          <div className="col-12">
            <div className='text-danger'>{nameerror}</div>
            <label for="movieName" className="form-label">Movie Name</label>
            <input type="text" className="form-control ms-2  w-100 mt-3" id="movieName" value={newMovie.movieName}
              onChange={(e) => setNewMovie({ ...newMovie, movieName: e.target.value })}
            />
          </div><br />
          <div className="col-12">
          <div className='text-danger'>{typeerror}</div>

            <label for="movieType" className="form-label">Movie Type</label>
            <input type="text" className="form-control ms-2 w-100 mt-3" id="movieType" value={newMovie.movieType}
              onChange={(e) => setNewMovie({ ...newMovie, movieType: e.target.value })}
            />
          </div>
          <div className="col-12">
          <div className='text-danger'>{langerror}</div>

            <label for="movieLanguage" className="form-label">Movie Language</label>
            <input type="text" className="form-control ms-2 w-100 mt-3" id="movieLanguage" placeholder="" value={newMovie.movieLanguage}
              onChange={(e) => setNewMovie({ ...newMovie, movieLanguage: e.target.value })} />
          </div>
          <div className="col-12">
          <div className='text-danger'>{duraerror}</div>

            <label for="movieDurations" className="form-label">MovieDurations</label>
            <input type="text" className="form-control ms-2 w-100 mt-3" id="movieDurations" placeholder="" value={newMovie.movieDurations}
              onChange={(e) => setNewMovie({ ...newMovie, movieDurations: e.target.value })} />
          </div>




          {/* <div className="col-12">
            <div className="form-check">
              <input className="form-check-input" type="checkbox" id="gridCheck" />
              <label className="form-check-label" for="gridCheck">
                I assure that above information given by me is correct
              </label>
            </div>
          </div> */}
          <div className="col-12">
            <button type="submit" onClick={(e) => { addupdateProduct(newMovie.movieId); e.preventDefault() }} className="btn btn-primary mt-3">{btnname}</button>
          </div>
        </form>
        </div>
       
      </section>

    </div>
  )
}

export default CreateUpdateMovie