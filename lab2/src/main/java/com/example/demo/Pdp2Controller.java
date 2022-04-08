package com.example.demo;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.nio.file.Path;

@Controller
public class Pdp2Controller {

    @RequestMapping("/example")
    public String index() {

        return "Index";
    }
}