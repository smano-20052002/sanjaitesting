import React from 'react'
import axios from 'axios';
import { render, fireEvent } from '@testing-library/react';
import { useNavigate } from 'react-router-dom';
import RegisterComponent from '../Component/RegisterComponent';

jest.mock('axios');
jest.mock('../Style/CreateUpdateComponent.css');
jest.mock('react-router-dom');

test('RENDER THE REGISTER FORM CHECK LABEL', async () => {
  const { getByLabelText } =
      render(<RegisterComponent />);
  expect(getByLabelText('Enter a email')).toBeInTheDocument();
  expect(getByLabelText('Enter a name')).toBeInTheDocument();
  expect(getByLabelText('Enter a password')).toBeInTheDocument();
});
test('RENDER THE REGISTER FORM CHECK BUTTON EXISTS', async () => {
  const { getByText } =
      render(<RegisterComponent />);
 expect(getByText('Login')).toBeInTheDocument();
  expect(getByText('Register')).toBeInTheDocument();
  

});
  



  test('shows error messages if email or password is empty', () => {
    // render the component
    const { getByText ,getByTestId} = render(<RegisterComponent/>);
    // get the elements
    
    const RegisterButton = getByText('Register');
    // click the login button

    fireEvent.click(RegisterButton);
    // check if the error messages are shown
    expect(getByTestId('useremailerror')).toHaveTextContent('Please enter a email');
    expect(getByTestId('userpwderror')).toHaveTextContent('Please enter a password');
    expect(getByTestId('usernameerror')).toHaveTextContent('Please enter a username');
  });
  
  test('calls post axios if the login is successful', async () => {
    // render the component
    const { getByText,getByRole } = render(<RegisterComponent/>);
    // get the elements
    const nameInput = getByRole('registerinput1', { id: 'UserName' });
    const emailInput = getByRole('registerinput2', { id: 'UserEmail' });
    const passwordInput = getByRole('registerinput3', { id: 'UserPassword' });
    const registerButton = getByText('Register');
    // enter some valid data
    fireEvent.change(emailInput, { target: { value: 'Karthick@gmail.com' } });
    fireEvent.change(passwordInput, { target: { value: 'Karthick123' } });
    fireEvent.change(nameInput, { target: { value: 'Karthick' } });
    // mock the axios.post response
    axios.post.mockResolvedValue({ data: { account: true, emailstatus: true, passwordstatus: true } });
    // mock the useNavigate function
    const navigate = useNavigate();
    // click the login button
    fireEvent.click(registerButton);
    // wait for the axios.post call
    await expect(axios.post).toHaveBeenCalled();
  
  });


  