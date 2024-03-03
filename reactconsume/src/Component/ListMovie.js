import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import Box from '@mui/material/Box';
import '../Style/CreateUpdateComponent.css'
import Modal from '@mui/material/Modal';
function ListMovie() {
    const [open, setOpen] = useState()
    const [deleteId, setDeleteId] = useState('')
    const [movie, setMovie] = useState([]);
    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 500,
        height: 200,
        bgcolor: 'background.paper',
        border: '1px solid #000',
        boxShadow: 24,
        pt: 3,
        px: 3,
        pb: 3,
    };
    const deleteDialog = (id) => {
        setDeleteId(id); handleOpen();
    }
    const deleteMovie = (id) => {
        axios.delete(`/apiGateway/DeleteMovie/${id}`).then(() => {
            console.log("Deleted successfully");
        });
        setOpen(false);
        axios.get('/apiGateway/FetchMovie').then((response) => {
            setMovie(response.data);
            console.log(response.data);
            console.log("o", movie);
        }).catch((error) => {
            console.error("error occured in fetch effect")
        });

    };
    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    useEffect(() => {
        axios.get('/apiGateway/FetchMovie').then((response) => {
            setMovie(response.data);
            console.log(response.data);
            console.log("o", movie);
        }).catch((error) => {
            console.error("error occured in fetch effect")
        });
        
    }, []);
    return (
        <div>
            <div className='centeritem1 d-flex flex-column '>
            <div className=''><Link to='/create' className='btn btn-outline-success d-flex addbtn mb-5'>Add Movie</Link>
            </div>
            <section className='tcontent'>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Movie Name</th>
                        <th scope="col">Movie Language</th>
                        <th scope="col">Movie Type</th>
                        <th scope="col">Movie Durations</th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody className='tcontent'>

                    {movie.map((data) => (
                        <tr scope="row" >
                            <td className=''>{data.movieId}</td>
                            <td className=''>{data.movieName}</td>
                            <td className=''>{data.movieLanguage}</td>
                            <td className=''>{data.movieType}</td>
                            <td className=''>{data.movieDurations}</td>
                            <td className="">
                                <button type="submit" onClick={(e) => { deleteDialog(data.movieId); e.preventDefault() }} className="btn btn-primary">Delete</button>
                                {/* <button type="submit" onClick={(e) => { updateProduct(data.productId); e.preventDefault() }} className="btn btn-primary">Update</button> */}
                                <Link to={`/create/${data.movieId}`} className='btn'>Update</Link>
                            </td>

                        </tr>
                    ))}


                </tbody>
            </table>
            </section>
            </div>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="parent-modal-title"
                aria-describedby="parent-modal-description"
            >
                <Box sx={{ ...style, width: 500 }}>
                    <h2 style={{}} id="parent-modal-title">Confirm Delete</h2><hr />
                    <p id="parent-modal-description">
                        Make sure you want to delete?
                    </p>
                    <button className='btn btn-danger me-3' onClick={() => {
                        deleteMovie(deleteId)
                    }}>
                        Delete
                    </button>
                    <button className='btn btn-secondary' onClick={handleClose}>
                        Cancel
                    </button>

                </Box>
            </Modal>
        </div>
    )
}

export default ListMovie