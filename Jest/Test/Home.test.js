
import { fireEvent, render, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import {  BrowserRouter,useLocation,useNavigate,Route, Routes } from "react-router-dom";
import HomeComponent from "../Component/HomeComponent";
import ListMovie from '../Component/ListMovie'


describe(" Check exist of Total movies label ", () => {
  it("Renders the Home component", async () => {
    const { getByText } = render(<BrowserRouter>
      <HomeComponent/>
    </BrowserRouter>,);

    const label = getByText(/Total Movies/i);
    expect(label).toBeInTheDocument();
  });
});
describe(" Check exist of Add movie button ", () => {
    it("Renders the Home component", async () => {
      const { getByRole } = render(<BrowserRouter>
        <HomeComponent/>
      </BrowserRouter>,);
  
      const button=getByRole('link', { name: "Add Movie" })
      
      await expect(button).toBeInTheDocument();
    });
  });

  describe(" Check redirection after click add movie button ", () => {
    it("Renders the Home component", async () => {
      const { getByRole } = render(<BrowserRouter>
        <HomeComponent/>
      </BrowserRouter>);
  
      const button=getByRole('link', { name: "Add Movie" })
      
      fireEvent.click(button);
      const title = global.window.location.href;
      expect(title).toBe("http://localhost/create");
    });
  });
  describe(" Check whether the list button is exists", () => {
    it("Renders the Home component", async () => {
      const { getByRole } = render(<BrowserRouter>
        <HomeComponent/>
      </BrowserRouter>);
  
      const button=getByRole('link', { name: "List Movie" })
      
      expect(button).toBeInTheDocument();
    });
  });

  describe("Check whether the list button redirects to list component ", () => {
    it("Renders the Home component", async () => {
      const { getByRole } = render(<BrowserRouter>
        <HomeComponent/>
      </BrowserRouter>,);
  
      const button=getByRole('link', { name: "List Movie" })
      
      fireEvent.click(button);
      const title = global.window.location.href;
      expect(title).toBe("http://localhost/list");
    });
  });