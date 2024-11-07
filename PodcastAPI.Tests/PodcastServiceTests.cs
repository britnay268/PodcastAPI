using Xunit;
using Moq;
using PodcastAPI.Services;
using PodcastAPI.Interfaces;
using PodcastAPI.Models;
using PodcastAPI.DTOs;
namespace PodcastAPI.Tests;

using System;
using System.Net;
using PodcastAPI.DTOs;
using PodcastAPI.Interfaces;
using PodcastAPI.Models;
using PodcastAPI.Services;

public class PodcastServiceTests
{
    private readonly PodcastService _podcastService;

    private readonly Mock<IPodcastRepository> _mockPodcastRepository;

    public PodcastServiceTests()
    {
        _mockPodcastRepository = new Mock<IPodcastRepository>();
        _podcastService = new PodcastService(_mockPodcastRepository.Object);
    }


    [Fact]
    public async Task GetPodcastDeatils_ShouldReturnPodcast_WhenPodcastExists()
    {
        int podcastId = 2;

        Podcast expectedPodcast = new Podcast { Id = podcastId, Title = "The title", Description = "The podcast description" };

        _mockPodcastRepository.Setup(repo => repo.GetPodcastByIdAsync(podcastId)).ReturnsAsync(expectedPodcast);

        var actualPodcast = await _podcastService.GetPodcastByIdAsync(podcastId);

        Assert.Equal(expectedPodcast, actualPodcast);
    }

    [Fact]
    public async Task AddPodcast_ShouldReturnPodcast_WhenItExists()
    {
        var newPodcast = new PodcastSubmitDTO { Title = "The title", Description = "The podcast description" };
        var expectedPodcast = new Podcast { Id = 5, Title = "The title", Description = "The podcast description" };

        _mockPodcastRepository.Setup(repo => repo.CreatePodcastAsync(newPodcast))
            .ReturnsAsync(expectedPodcast);

        var actualPodcast = await _podcastService.CreatePodcastAsync(newPodcast);

        Assert.Equal(expectedPodcast, actualPodcast);

    }

    [Fact]
    public async Task GetAllPodcasts_ShouldReturnListofPodcasts()
    {
        var expectedPodcastList = new List<Podcast>
        {
            new Podcast { Id = 5, Title = "The title", Description = "The podcast description" },
            new Podcast { Id = 6, Title = "The title 2", Description = "The podcast description 2" }
        };

        _mockPodcastRepository.Setup(repo => repo.GetPodcastsAsync()).ReturnsAsync(expectedPodcastList);

        List<Podcast> actualPodcastList = await _podcastService.GetPodcastsAsync();

        Assert.Equal(expectedPodcastList, actualPodcastList);
    }


    [Fact]
    public async Task UpdatePodcast_ShouldReturnsTheUpdatedPodcast_WhenUpdateIsSuccessful()
    {
        int podcastId = 5;
        var podcastToUpdate = new PodcastSubmitDTO { Id = 5, Title = "The title", Description = "The podcast description" };
        var expectedPodcast = new Podcast { Id = 5, Title = "The title", Description = "The podcast description" };


        _mockPodcastRepository.Setup(repo => repo.UpdatePodcastAsync(podcastId, podcastToUpdate)).ReturnsAsync(expectedPodcast);

        var actualPodcastToUpdate = await _podcastService.UpdatePodcastAsync(podcastId, podcastToUpdate);

        Assert.Equal(expectedPodcast, actualPodcastToUpdate);
    }

    [Fact]
    public async Task DeletePodcast_ShouldReturnTheDeleted_WhenDeleteIsSuccessfil()
    {
        int podcastId = 5;

        var podcastToDelete = new Podcast { Id = 5, Title = "The title", Description = "The podcast description" };

        _mockPodcastRepository.Setup(repo => repo.DeletePodcastAsync(podcastId)).ReturnsAsync(podcastToDelete);

        var actualPodcastToDelete = await _podcastService.DeletePodcastAsync(podcastId);

        Assert.Equal(podcastToDelete, actualPodcastToDelete);
    }
}
